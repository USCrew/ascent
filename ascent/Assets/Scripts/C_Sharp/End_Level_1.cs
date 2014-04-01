using UnityEngine;
using System.Collections.Generic;

public class End_Level_1 : MonoBehaviour {

	public GameObject Green;
	public GameObject Red;

	public Queue<string> EndPoints;

	// Use this for initialization
	void Start () {
		EndPoints = new Queue<string>();
		EndPoints.Enqueue("level_2");
		EndPoints.Enqueue("level_3");
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
		string current = EndPoints.Dequeue();
		Application.LoadLevel(current);
	}
}
