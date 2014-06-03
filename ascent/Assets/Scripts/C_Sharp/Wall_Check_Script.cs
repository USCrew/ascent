using UnityEngine;
using System.Collections;

public class Wall_Check_Script : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3  newBoundPos = new Vector3(
			player.transform.position.x,
			player.transform.position.y - .3f,
			player.transform.position.z
			);
		transform.position = newBoundPos;
	}

	
	void OnTriggerStay2D(Collider2D collision) {
		if(collision.gameObject.tag == "Wall")
		{
			player.GetComponent<Player>().isClimbing = true;
			player.rigidbody2D.gravityScale = 0;
		}
	}

	void OnTriggerExit2D(Collider2D collision) {
		if(collision.tag == "Wall") {
			player.GetComponent<Player>().isClimbing = false;
			player.rigidbody2D.gravityScale = 1;
		}
	}
}
