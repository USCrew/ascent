using UnityEngine;
using System.Collections;

public class Spike : LevelObject {
	
	public Sprite Blood1;
	public Sprite Blood2;
	public Sprite Blood3;
	public AudioClip die;

	private enum Blood {blood0, blood1, blood2, blood3};
	private Blood currentBlood;

	protected override void Awake () {
		base.Awake();
		currentRotation = Rotations.down;
		currentBlood = Blood.blood0;
	}

	// Update is called once per frame
	protected override void Update () {
		base.Update ();
		if (editor) {
			if (selected) {
				if (Input.GetKeyDown("d")) {
					gameObject.transform.Rotate(new Vector3(0,0,-90));
					currentRotation = GetNextRotation ("right");
				}
				if (Input.GetKeyDown("a")) {
					gameObject.transform.Rotate(new Vector3(0,0,90));
					currentRotation = GetNextRotation ("left");
				}
				if(worldMousePos.x >= 0 && worldMousePos.y >= 0 && worldMousePos.x <= (width * 5) - .2 && worldMousePos.y <= (height * 5) - .2) {
					if(currentRotation == Rotations.down) {
						gameObject.transform.position = new Vector3((float)(worldMousePos.x) + 2.5f, (float)(worldMousePos.y) + 3.5f, 0);
					}
					else if(currentRotation == Rotations.up) {
						gameObject.transform.position = new Vector3((float)(worldMousePos.x) + 2.5f, (float)(worldMousePos.y) + 1.5f, 0);
					}
					else if(currentRotation == Rotations.right) {
						gameObject.transform.position = new Vector3((float)(worldMousePos.x) + 3.5f, (float)(worldMousePos.y) + 2.5f, 0);
					}
					else if(currentRotation == Rotations.left) {
						gameObject.transform.position = new Vector3((float)(worldMousePos.x) + 1.5f, (float)(worldMousePos.y) + 2.5f, 0);
					}
				}
			}
		}
	}

	void OnTriggerStay2D(Collider2D collision) {
		collision.enabled = false;
		player.transform.localPosition = player.GetComponent<Player>().getCurrentCheckpointPos();
		player.rigidbody2D.velocity = Vector3.zero;
		audio.PlayOneShot(die);

		switch(currentBlood) {
			case Blood.blood0:
				GetComponent<SpriteRenderer>().sprite = Blood1;
				currentBlood = Blood.blood1;
				break;
			case Blood.blood1:
				GetComponent<SpriteRenderer>().sprite = Blood2;
				currentBlood = Blood.blood2;
				break;
			case Blood.blood2:
				GetComponent<SpriteRenderer>().sprite = Blood3;
				currentBlood = Blood.blood3;
				break;
		}
		collision.enabled = true;
	}

	public override void setPositionRotation(int Col, int Row, int Rot) {
		if(Rot == 0) {
			gameObject.transform.rotation = Quaternion.AngleAxis(0f, new Vector3(0, 0, 1));
			gameObject.transform.position = new Vector3((float)(Col * 2.5) + 2.5f, (float)(Row * 5) + 3.5f, 0);
		}
		else if(Rot == 2) {
			gameObject.transform.rotation = Quaternion.AngleAxis(180f, new Vector3(0, 0, 1));
			gameObject.transform.position = new Vector3((float)(Col * 2.5) + 2.5f, (float)(Row * 5) + 1.5f, 0);
		}
		else if(Rot == 1) {
			gameObject.transform.rotation = Quaternion.AngleAxis(-90f, new Vector3(0, 0, 1));
			gameObject.transform.position = new Vector3((float)(Col * 2.5) + 3.5f, (float)(Row * 5) + 2.5f, 0);
		}
		else if(Rot == 3) {
			gameObject.transform.rotation = Quaternion.AngleAxis(90f, new Vector3(0, 0, 1));
			gameObject.transform.position = new Vector3((float)(Col * 2.5) + 1.5f, (float)(Row * 5) + 2.5f, 0);
		}
	}
}