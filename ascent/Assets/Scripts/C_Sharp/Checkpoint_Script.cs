using UnityEngine;
using System.Collections;

public class Checkpoint_Script : MonoBehaviour {

	public GameObject Green;
	public GameObject Red;

	public Climbing climb_script;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}

	public void activate()
	{
		Green.SetActive(true);
		Red.SetActive(false);
	}

	public void deactivate()
	{
		Green.SetActive(false);
		Red.SetActive(true);
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		climb_script.setCurrentCheckpoint(gameObject);
	}
}
