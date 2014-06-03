using UnityEngine;
using System.Collections;

public class Right_Script : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update () 
	{
		Vector3  newBoundPos = new Vector3(
			player.transform.position.x,
			player.transform.position.y,
			player.transform.position.z
			);
		transform.position = newBoundPos;
	}
	
	void OnTriggerStay2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Wall")
		{
			player.GetComponent<Player>().whichSide = 2;
		}
	}
	
	void OnTriggerExit2D(Collider2D collision)
	{
		if(collision.tag == "Wall") 
		{
			player.GetComponent<Player>().whichSide = 0;
		}
	}
}
