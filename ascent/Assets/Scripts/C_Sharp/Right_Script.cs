using UnityEngine;
using System.Collections;

public class Right_Script : MonoBehaviour {

	public GameObject player;
	public Climbing climb_script;

	// Use this for initialization
	void Update () {
		Vector3  poop = new Vector3(
			player.transform.position.x,
			player.transform.position.y,
			player.transform.position.z
			);
		transform.position = poop;
	}
	
	void OnTriggerStay2D(Collider2D collision){
		if(collision.gameObject.tag == "Wall"){
			climb_script.whichSide = 2;
		}
	}
	
	void OnTriggerExit2D(Collider2D collision){
		if(collision.tag == "Wall") {
			climb_script.whichSide = 0;
		}
	}
}
