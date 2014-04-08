using UnityEngine;
using System.Collections;

public class DontDieOnMeNow : MonoBehaviour {

	public GameObject Player;
	public Climbing climb_script; 
	public MetricManagerScript mms;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collision){
		Player.transform.localPosition = climb_script.getCurrentCheckpointPos();
		Player.rigidbody2D.velocity = Vector3.zero;
		mms.AddToNumberDeaths();


	}

}
