using UnityEngine;
using System.Collections;

public class PlayerLightManagerScript : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3  poop = new Vector3(
			player.transform.position.x,
			player.transform.position.y + .4f,
			player.transform.position.z
			);
		transform.position = poop;
	}
}
