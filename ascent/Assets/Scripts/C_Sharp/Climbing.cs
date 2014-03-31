using UnityEngine;
using System.Collections;

public class Climbing : MonoBehaviour {

	//Speed Multiplier
	public float speed =1.0f;
	public float vel;


	//On Da Ground
	private int vert_speed = 150;
	private int horz_speed = 20;

	//Climbing
	private float climb_speed = 10f;
	public GameObject StartingCheckpoint;
	private GameObject CurrentCheckpoint;

	//State Checks
	public bool isClimbing = false;
	public bool isGrounded = false;

	//Animation
	public Animator anim;
	

	// Use this for initialization
	void Start () {

		setCurrentCheckpoint(StartingCheckpoint);
		//anim.animation["Walk_Left"].speed = -1f;
		//anim.animation["Walk_Right"].speed = 0.01f;
		//anim.speed = 0.1f;


	}

	// Update is called once per frame
	void Update () {


		//TODO THIS SHIT
		/*

		if (Input.GetKey(KeyCode.Escape))
		{
			Application.LoadLevel("main_menu");
		}

		if (Input.GetKeyDown("p")){
			if( Time.timeScale > 0)
			{
				Time.timeScale =0;

			}

			else Time.timeScale = 1;
		}

		*/

		if (Input.GetKeyDown("p")){
			if( Time.timeScale > 0)
			{
				Time.timeScale =0;
			}
			else Time.timeScale = 1;
		}

		if (Time.timeScale>0)
		{
		if ((!Input.GetKey(KeyCode.UpArrow)&&!Input.GetKey(KeyCode.DownArrow)) && isClimbing){
			rigidbody2D.velocity = Vector3.zero;
		}


			if(!isGrounded && !isClimbing)
			{
				anim.SetInteger("State", 0);
				//anim.Play("Idle", 1, .01f);
			}

		if(isGrounded && rigidbody2D.velocity.x < 1 && !isClimbing)
			{
				anim.SetInteger("State", 0);
				//anim.Play("Idle", 1, .01f);
			}

			if(isClimbing && Mathf.Abs(rigidbody2D.velocity.y)>1)
			{
				anim.SetInteger("State", 7);
				//anim.Play("Climb_General", 1, .01f);
			}

			if(isClimbing && Mathf.Abs(rigidbody2D.velocity.y)<1)
			{
				anim.SetInteger("State", 0);
				//anim.Play("Climb_General", 1, .01f);
			}

		/**
		 *Code Used For Moving Up on Walls and Jumping
		 * Used Forces for Jumps
		 */
		if (Input.GetKey(KeyCode.UpArrow) && (isClimbing || isGrounded))
			{
			if(isClimbing){	//Climb
				if(rigidbody2D.velocity.y < 3)
				{
					rigidbody2D.velocity = new Vector3(0,3,0);
				}
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
				anim.SetInteger("State", 4);

		} 
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			rigidbody2D.AddForce(Vector3.left * horz_speed);
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
		if(CurrentCheckpoint != null){
			Checkpoint_Script deact=(Checkpoint_Script) CurrentCheckpoint.GetComponent(typeof(Checkpoint_Script));
			
			deact.deactivate();
		}
		CurrentCheckpoint = newCurrent;
		Checkpoint_Script act=(Checkpoint_Script) CurrentCheckpoint.GetComponent(typeof(Checkpoint_Script));

		act.activate();
	}
}