using UnityEngine;
using System.Collections;

public class AnnoyYou : MonoBehaviour {
	public GameObject player;

	void Start(){
	}


	void Update () {
		Vector3  poop = new Vector3(
			player.transform.position.x,
			player.transform.position.y + 1f,
			player.transform.position.z
			);
		transform.position = poop;

	}



}
