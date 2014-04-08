using UnityEngine;
using System.Collections;

public class SpikeScript : MonoBehaviour {
	
	public GameObject Player;
	public Climbing climb_script; 
	public Sprite Blood1;
	public Sprite Blood2;
	public Sprite Blood3;
	private int count = 0;
	public MetricManagerScript mms;
	
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerStay2D(Collider2D collision){

		if ( count == 1){
			GetComponent<SpriteRenderer>().sprite = Blood2;
			count ++;
		}
		
		if ( count == 0){
			GetComponent<SpriteRenderer>().sprite = Blood1;
			count ++;
		}

		Player.transform.localPosition = climb_script.getCurrentCheckpointPos();
		Player.rigidbody2D.velocity = Vector3.zero;
		mms.AddToNumberDeaths();
		
	}
	
}
