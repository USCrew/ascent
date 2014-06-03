using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 cameraPos = new Vector3(player.transform.position.x, player.transform.position.y, gameObject.transform.position.z);
		gameObject.transform.position = cameraPos;
	}
}
