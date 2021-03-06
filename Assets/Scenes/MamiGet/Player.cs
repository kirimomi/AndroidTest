﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame

	//const float PLAYER_MAX_SPD = 20.0f;
	const float PLAYER_MAX_SPD = 200.0f;

	const float PLAYER_SPD = 2.0f;

	const float SCREEN_EDGE_X = 2.8f;

	//const float SCALE_PER_MAMI = 0.18f;
	const float SCALE_PER_MAMI = 0.3f;

	void Update ()
	{

		//===============普通に操作する実験===============
		/*
		Vector3 spd = Vector3.zero;
		if (Input.GetKey ("up")) {
			spd += Vector3.up * PLAYER_MAX_SPD;
		}
		if (Input.GetKey ("down")) {
			spd += Vector3.down * PLAYER_MAX_SPD;
		}
		if (Input.GetKey ("left")) {
			spd += Vector3.left * PLAYER_MAX_SPD;
		}
		if (Input.GetKey ("right")) {
			spd += Vector3.right * PLAYER_MAX_SPD;
		}
		transform.position =  transform.position + spd * Time.deltaTime;
		*/

		//===============クリックしたところに移動実験===============
		/*
		if(Input.GetMouseButton(0)){
			Vector3 mousePos =Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 targetPos = mousePos + Vector3.up * 1.5f;
			targetPos.z = 0;
			transform.position = Vector3.MoveTowards(transform.position, targetPos, PLAYER_MAX_SPD * Time.deltaTime);
		}*/

		//===============1ボタン操作実験===============
		if (0 < MainSystem.Counter) {
			Vector3 spd = Vector3.zero;
			if (Input.GetMouseButton (0)) {
				spd.x = PLAYER_SPD;
			} else {
				spd.x = -PLAYER_SPD;
			}
			Vector3 targetPos = transform.position + spd * Time.deltaTime;

			float limitX = SCREEN_EDGE_X - GetPlayerRadius ();
			targetPos.x = Mathf.Clamp (targetPos.x, -limitX, limitX);
			transform.position = targetPos;
		}

		//プイレイヤーのスケール

		//transform.localScale = Vector3.one + Vector3.one * SCALE_PER_MAMI * Mathf.Sqrt (MainSystem.Score);
		transform.localScale = Vector3.one * 0.7f + Vector3.one * SCALE_PER_MAMI * Mathf.Sqrt (MainSystem.Score);

	}


	float GetPlayerRadius(){
		float radius = GetComponent<CircleCollider2D> ().radius * transform.localScale.x;
		//Debug.Log ("radius is " + radius);
		return radius;
	}
}
