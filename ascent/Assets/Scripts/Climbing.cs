using UnityEngine;
using System.Collections;

public class Climbing : MonoBehaviour {

	public float speed =1.0f;
	public int vert_speed = 30;
	public int horz_speed = 20;

	public bool isClimbing = false;
	public bool isGrounded = false;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newVelocity = Vector3.zero;




		if (Input.GetKey(KeyCode.UpArrow) && (isClimbing || isGrounded))
		{
			//newVelocity.y = 7.0f;
			//transform.position += newVelocity * Time.deltaTime * speed;

			rigidbody2D.AddForce(Vector3.up * vert_speed);
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			//newVelocity.y = -7.0f;
			//transform.position += newVelocity * Time.deltaTime * speed;
		} 




		if (Input.GetKey(KeyCode.RightArrow))
		{
			//newVelocity.x = 7.0f;
			//transform.position += newVelocity * Time.deltaTime * speed;

			rigidbody2D.AddForce(Vector3.right * horz_speed);
		} 
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			//newVelocity.x = -7.0f;
			transform.position += newVelocity * Time.deltaTime * speed;

			rigidbody2D.AddForce(Vector3.left * horz_speed);
		}
	}
}