using UnityEngine;
using System.Collections.Generic;

public class EndLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}
	
	void OnTriggerEnter2D(Collider2D collision)
	{
		Application.LoadLevel("main_menu");
	}
}
