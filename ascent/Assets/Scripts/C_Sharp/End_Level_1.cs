using UnityEngine;
using System.Collections.Generic;

public class End_Level_1 : MonoBehaviour {
	
	public string next;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D collision){
		
		Application.LoadLevel(next);
	}
}
