using UnityEngine;
using System.Collections;

public class Climbing : MonoBehaviour {
	
	public float speed =1.0f;
		
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 newVelocity = Vector3.zero;




		if (Input.GetKey(KeyCode.UpArrow))
		{
			newVelocity.y = 7.0f;

			transform.position += newVelocity * Time.deltaTime * speed;
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			newVelocity.y = -7.0f;
			
			transform.position += newVelocity * Time.deltaTime * speed;
		} 




		if (Input.GetKey(KeyCode.RightArrow))
		{
			newVelocity.x = 7.0f;
			
			transform.position += newVelocity * Time.deltaTime * speed;
		} 
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			newVelocity.x = -7.0f;
			
			transform.position += newVelocity * Time.deltaTime * speed;
		} 
	}
}