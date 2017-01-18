﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour {

	public GameObject MamiPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame

	float m_mamiPerSec;

	const float MAMI_PER_SEC_MIN = 3f;//最小秒間出現（初期値）
	const float MAMI_PER_SEC_MAX = 15f;//最大秒間出現
	const float MAMI_PER_SEC_MAX_TIME = 25f;//この秒数でMAX

	float m_mamiCounter = 0;

	void Update () {

		float elaspedTime = (MainSystem.PLAY_TIME - MainSystem.Counter);
		m_mamiPerSec = MAMI_PER_SEC_MIN + (MAMI_PER_SEC_MAX - MAMI_PER_SEC_MIN) / MAMI_PER_SEC_MAX_TIME * elaspedTime;

		if (MAMI_PER_SEC_MAX < m_mamiPerSec) {
			m_mamiPerSec = MAMI_PER_SEC_MAX;
		}

		if (0 < MainSystem.Counter && 1.0f / m_mamiPerSec < m_mamiCounter) {
			MakeMami ();
			m_mamiCounter = 0;
		}

		m_mamiCounter += Time.deltaTime;
	}

	const float MAMI_START_POS_Y = 6.5f;
	const float MAMI_START_POS_X = 2.2f;


	void MakeMami(){
		Vector3 pos = Vector3.up * MAMI_START_POS_Y;
		pos.x = Random.Range (-MAMI_START_POS_X, MAMI_START_POS_X);
		GameObject obj = Instantiate (MamiPrefab, pos ,Quaternion.identity);


		//Vector3 spd = Vector3.up * -3.0f;
		Vector3 spd = Vector3.zero;
		if (20f < MainSystem.Counter) {
			spd.x = Random.Range (-5.0f, 5.0f);
			spd.y = -3f;
		} else if (10f < MainSystem.Counter) {
			spd.x = Random.Range (-8.0f, 8.0f);
			spd.y = Random.Range (-3f, -5f);
		} else if (5f < MainSystem.Counter) {
			spd.x = Random.Range (-10.0f, 10.0f);
			spd.y = Random.Range (-3f, -10f);
		} else {
			spd.x = Random.Range (-14.0f, 14.0f);
			spd.y = Random.Range (-5f, -15f);
		}
		obj.GetComponent<Mami>().SetSpeed(spd);
	}
}