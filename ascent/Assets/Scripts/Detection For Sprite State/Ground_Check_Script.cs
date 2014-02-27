﻿using UnityEngine;
using System.Collections;

public class Ground_Check_Script : MonoBehaviour {

	public GameObject player;
	public GameObject wall;
	public Climbing climb_script;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position;

	}
	
	void OnTriggerEnter2D(Collider2D collision){
		Debug.Log("Collision");
		if(collision.gameObject.tag == "Wall"){
			climb_script.isGrounded = true;
		}
	}

	void OnTriggerExit2D(Collider2D collision){
		Debug.Log("CollisionX");
		if(collision.tag == "Wall") {
			climb_script.isGrounded = false;
		}
	}
}
