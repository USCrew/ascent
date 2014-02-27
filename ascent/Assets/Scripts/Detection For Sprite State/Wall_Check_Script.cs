using UnityEngine;
using System.Collections;

public class Wall_Check_Script : MonoBehaviour {

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

	
	void OnCollisionEnter2D(Collision2D theCollision){
		if(theCollision.gameObject.tag == "Wall"){
			climb_script.isClimbing = true;
		}
	}
}
