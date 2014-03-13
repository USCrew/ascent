using UnityEngine;
using System.Collections;

public class Climbing : MonoBehaviour {

	//Speed Multiplier
	public float speed =1.0f;
	public float vel;


	//On Da Ground
	private int vert_speed = 300;
	private int horz_speed = 20;

	//Climbing
	private float climb_speed = 15f;
	public GameObject StartingCheckpoint;
	private GameObject CurrentCheckpoint;

	//State Checks
	public bool isClimbing = false;
	public bool isGrounded = false;

	// Use this for initialization
	void Start () {

		setCurrentCheckpoint(StartingCheckpoint);

	}

	// Update is called once per frame
	void Update () {


		if ((!Input.GetKey(KeyCode.UpArrow)&&!Input.GetKey(KeyCode.DownArrow)) && isClimbing){
			rigidbody2D.velocity = Vector3.zero;
		}

		/**
		 *Code Used For Moving Up on Walls and Jumping
		 * Used Forces for Jumps
		 */
		if (Input.GetKey(KeyCode.UpArrow) && (isClimbing || isGrounded))
			{
			if(isClimbing){	//Climb
				rigidbody2D.AddForce(Vector3.up * climb_speed);
			}
			else{	//Jump
				rigidbody2D.AddForce(Vector3.up * vert_speed);

			}
		}
		/**
		 *Code Used For Moving Down on Climbing
		 */
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			if(isClimbing){	//Climb
				rigidbody2D.AddForce(Vector3.down * climb_speed);
			} 
		}

		/**
		 *Code Used For Moving Left and Right
		 * Used Forces
		 */
		if (Input.GetKey(KeyCode.RightArrow))
		{
			rigidbody2D.AddForce(Vector3.right * horz_speed);
		} 
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			rigidbody2D.AddForce(Vector3.left * horz_speed);
		}
	}

	public Vector3 getCurrentCheckpointPos()
	{
		return CurrentCheckpoint.transform.position;
	}

	public void setCurrentCheckpoint(GameObject newCurrent)
	{
		if(CurrentCheckpoint != null){
			Checkpoint_Script deact=(Checkpoint_Script) CurrentCheckpoint.GetComponent(typeof(Checkpoint_Script));
			
			deact.deactivate();
		}
		CurrentCheckpoint = newCurrent;
		Checkpoint_Script act=(Checkpoint_Script) CurrentCheckpoint.GetComponent(typeof(Checkpoint_Script));

		act.activate();
	}
}