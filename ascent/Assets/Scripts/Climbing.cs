using UnityEngine;
using System.Collections;

public class Climbing : MonoBehaviour {
	
	public float speed =1.0f;
		
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey(Keycode.UpArrow))
		{
			Vector3 newVelocity = transform.localScale;
			newScale.y = 1.0f;

			transform.Position = newVelocity * Time.deltaTime * speed;
		} 
		else if (Input.GetKey(Keycode.RightArrow))
		{
			Vector3 newVelocity = transform.localScale;
			newScale.x = 1.0f;
			
			transform.Position = newVelocity * Time.deltaTime * speed;
		} 
		else if (Input.GetKey(Keycode.LeftArrow))
		{
			Vector3 newVelocity = transform.localScale;
			newScale.x = -1.0f;
			
			transform.Position += newVelocity * Time.deltaTime * speed;
		} 
	}
}