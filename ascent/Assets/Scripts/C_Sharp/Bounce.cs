using UnityEngine;
using System.Collections;

public class Bounce : LevelObject {

	protected override void Awake () {
		base.Awake ();
		currentRotation = Rotations.up;
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
						gameObject.transform.position = new Vector3((float)(worldMousePos.x) + 2.5f, (float)(worldMousePos.y) + 3.75f, 0);
					}
					else if(currentRotation == Rotations.up) {
						gameObject.transform.position = new Vector3((float)(worldMousePos.x) + 2.5f, (float)(worldMousePos.y) + 1.25f, 0);
					}
					else if(currentRotation == Rotations.right) {
						gameObject.transform.position = new Vector3((float)(worldMousePos.x) + 3.75f, (float)(worldMousePos.y) + 2.5f, 0);
					}
					else if(currentRotation == Rotations.left) {
						gameObject.transform.position = new Vector3((float)(worldMousePos.x) + 1.25f, (float)(worldMousePos.y) + 2.5f, 0);
					}
				}
			}
		}
	}

	public override void setPositionRotation(int Col, int Row, int Rot) {
		if(Rot == 0) {
			gameObject.transform.rotation = Quaternion.AngleAxis(0f, new Vector3(0, 0, 1));
			gameObject.transform.position = new Vector3((float)(Col * 2.5) + 2.5f, (float)(Row * 5) + 3.75f, 0);
		}
		else if(Rot == 2) {
			gameObject.transform.rotation = Quaternion.AngleAxis(180f, new Vector3(0, 0, 1));
			gameObject.transform.position = new Vector3((float)(Col * 2.5) + 2.5f, (float)(Row * 5) + 1.25f, 0);
		}
		else if(Rot == 1) {
			gameObject.transform.rotation = Quaternion.AngleAxis(-90f, new Vector3(0, 0, 1));
			gameObject.transform.position = new Vector3((float)(Col * 2.5) + 3.75f, (float)(Row * 5) + 2.5f, 0);
		}
		else if(Rot == 3) {
			gameObject.transform.rotation = Quaternion.AngleAxis(90f, new Vector3(0, 0, 1));
			gameObject.transform.position = new Vector3((float)(Col * 2.5) + 1.25f, (float)(Row * 5) + 2.5f, 0);
		}
	}
}