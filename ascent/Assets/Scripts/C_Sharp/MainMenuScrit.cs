﻿using UnityEngine;
using System.Collections;

public class MainMenuScrit : MonoBehaviour {

	public 


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.S)){
			Application.LoadLevel("sample_level");
		}

	
	}
}