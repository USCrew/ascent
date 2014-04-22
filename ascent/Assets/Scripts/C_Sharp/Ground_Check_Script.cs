using UnityEngine;
using System.Collections;

public class Ground_Check_Script : MonoBehaviour {

	public GameObject player;
	public GameObject wall;
	public Climbing climb_script;


	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3  poop = new Vector3(
			player.transform.position.x,
			player.transform.position.y - .3f,
			player.transform.position.z
			);
		transform.position = poop;
	}
	
	void OnTriggerStay2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Wall" || collision.tag == "DontClimb")
		{
			climb_script.isGrounded = true;
		}
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		if(collision.tag == "Wall" ||collision.tag == "DontClimb" ) 
		{
			climb_script.isGrounded = false;
		}
	}
}
