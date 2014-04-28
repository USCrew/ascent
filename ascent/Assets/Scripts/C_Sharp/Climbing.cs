using UnityEngine;
using System.Collections;

public class Climbing : MonoBehaviour {

	//Speed Multiplier
	public float speed = 1.0f;
	public float vel;


	//On The Ground
	private int vert_speed = 12000;
	private int horz_speed = 1200;

	//Climbing
	private float climb_speed = 600f;
	public GameObject StartingCheckpoint;
	private GameObject CurrentCheckpoint;

	//State Checks
	public bool isClimbing = false;
	public bool isGrounded = false;
	public int  whichSide = 0;	//0 is no wall, 1 is left, 2 is right
	public AudioClip bleep;

	//Animation
	public Animator anim;


	// Use this for initialization
	void Start () 
	{
		setCurrentCheckpoint(StartingCheckpoint);
	}

	// Update is called once per frame
	void Update () 
	{
		/* FOR PAUSING */
		if (Input.GetKeyDown("p"))
		{
			if( Time.timeScale > 0)
			{
				Time.timeScale = 0;
			}
			else Time.timeScale = 1;
		}

		if (Time.timeScale > 0)
		{
			if ((!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow)) && isClimbing)
			{
				rigidbody2D.velocity = Vector3.zero;
			}
		}

		/* FOR ANIMATION */
		if(!isGrounded && !isClimbing)
		{
			anim.SetInteger("State", 0);
		}

		if(isGrounded && rigidbody2D.velocity.x < 1 && !isClimbing)
		{
			anim.SetInteger("State", 0);
		}

		/**
		 *Code Used For Moving Up on Walls and Jumping
		 * Used Forces for Jumps
		 */

		if (!Input.GetKey(KeyCode.UpArrow)
			    || !Input.GetKey(KeyCode.DownArrow)
			    && (isClimbing || isGrounded))
		{
			if(whichSide == 1)
			{
				anim.SetInteger("State", 2);
			}

			if(whichSide == 2)
			{
				anim.SetInteger("State", 5);
			}
		}

		if (Input.GetKey(KeyCode.UpArrow) && (isClimbing || isGrounded))
		{
			if(isClimbing) //Climb
			{	
				/* Limit speed at 6 */
				if(rigidbody2D.velocity.y < 6)
				{
					rigidbody2D.velocity = new Vector3(0,6,0);
				}

				rigidbody2D.AddForce(Vector3.up * climb_speed * Time.deltaTime);

				/* For Animation */
				if(whichSide == 1)
				{
					anim.SetInteger("State", 3);
				}
				if(whichSide == 2)
				{
					anim.SetInteger("State", 6);
				}

			}
			else //Jump
			{
				rigidbody2D.AddForce(Vector3.up * vert_speed * Time.deltaTime);
			}
		}

		//TODO Add DeltaTime below this point
		/**
		 *Code Used For Moving Down on Climbing
		 */
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			/* Limit speed at -6 */
			if(rigidbody2D.velocity.y < -6 && isClimbing)
			{
					rigidbody2D.velocity = new Vector3(0,-6,0);
			}
			if(isClimbing)//Climb
			{
				rigidbody2D.AddForce(Vector3.down * climb_speed * Time.deltaTime);

				/* For Animation */
				if(whichSide == 1)
				{
					anim.SetInteger("State", 3);
				}
				if(whichSide == 2)
				{
					anim.SetInteger("State", 6);
				}

			} 
		}

		/*
		 * Code Used For Moving Left and Right
		 * Using Forces
		 */
		if (Input.GetKey(KeyCode.RightArrow))
		{
			rigidbody2D.AddForce(Vector3.right * horz_speed * Time.deltaTime);
			if (!isClimbing)
			{
				anim.SetInteger("State", 4);
			}
		} 
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			rigidbody2D.AddForce(Vector3.left * horz_speed * Time.deltaTime);
			if (!isClimbing)
			{
				anim.SetInteger("State", 1);
			}
		}
	}

	public Vector3 getCurrentCheckpointPos()
	{
		float rX = CurrentCheckpoint.transform.position.x;
		float rY = CurrentCheckpoint.transform.position.y;
		return new Vector3(rX, rY, 0f);
	}

	public void setCurrentCheckpoint(GameObject newCurrent)
	{
		if(CurrentCheckpoint != null)
		{
			Checkpoint_Script deact=(Checkpoint_Script) CurrentCheckpoint.GetComponent(typeof(Checkpoint_Script));
			deact.deactivate();
		}
		if(CurrentCheckpoint != newCurrent)
		{
			if(newCurrent.name == "Checkpoint")
			audio.PlayOneShot(bleep);
		}

		CurrentCheckpoint = newCurrent;
		Checkpoint_Script act=(Checkpoint_Script) CurrentCheckpoint.GetComponent(typeof(Checkpoint_Script));
		act.activate();
	}
}