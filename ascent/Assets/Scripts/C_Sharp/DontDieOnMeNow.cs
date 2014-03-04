using UnityEngine;
using System.Collections;

public class DontDieOnMeNow : MonoBehaviour {

	public GameObject Player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collision){
		Player.transform.localPosition = new Vector3(8, -25, 0);
	}

}
