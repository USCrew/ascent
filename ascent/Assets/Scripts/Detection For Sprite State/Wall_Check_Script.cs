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

	
	void OnTriggerEnter2D(Collider2D collision){
		Debug.Log("Wallz");
		if(collision.gameObject.tag == "Wall"){
			climb_script.isClimbing = true;
		}
	}

	void OnTriggerExit2D(Collider2D collision){
		Debug.Log("WallzX");
		if(collision.tag == "Wall") {
			climb_script.isClimbing = false;
		}
	}
}
