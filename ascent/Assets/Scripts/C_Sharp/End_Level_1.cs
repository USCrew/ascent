using UnityEngine;
using System.Collections.Generic;

public class End_Level_1 : MonoBehaviour {

	public GameObject Green;
	public GameObject Red;

	public string next;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void activate(){
		Green.SetActive(true);
		Red.SetActive(false);

	}

	public void deactivate(){
		Green.SetActive(false);
		Red.SetActive(true);
	}

	void OnTriggerEnter2D(Collider2D collision){
		Application.LoadLevel(next);
	}
}
