﻿using UnityEngine;
using System.Collections;

public class PlayerLightManagerScript : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3  lightPos = new Vector3(
			player.transform.position.x,
			player.transform.position.y + .4f,
			player.transform.position.z
			);
		transform.position = lightPos;
	}
}
