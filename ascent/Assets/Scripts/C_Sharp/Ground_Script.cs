using UnityEngine;
using System.Collections;

public class Ground_Script : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3  newBoundsPos = new Vector3(
			player.transform.position.x,
			player.transform.position.y - .3f,
			player.transform.position.z
			);
		transform.position = newBoundsPos;
	}
	
	void OnTriggerStay2D(Collider2D collision) {
		if(collision.gameObject.tag == "Wall" || collision.tag == "DontClimb") {
			player.GetComponent<Player>().isGrounded = true;
		}
	}

	void OnTriggerExit2D(Collider2D collision) {
		if(collision.tag == "Wall" ||collision.tag == "DontClimb" ) {
			player.GetComponent<Player>().isGrounded = false;
		}
	}
}
