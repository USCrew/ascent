using UnityEngine;
using System.Collections;

public class Checkpoint : LevelObject {

	public GameObject Green;
	public GameObject Red;

	// Update is called once per frame
	protected override void Update () {
		base.Update ();
		if (editor) {
			if (selected) {
				if(worldMousePos.x >= 0 && worldMousePos.y >= 0 && worldMousePos.x <= (width * 5) - .2 && worldMousePos.y <= (height * 5) - .2) {
					gameObject.transform.position = new Vector3((float)(worldMousePos.x) + 2.5f, (float)(worldMousePos.y) + 2.5f, 0);
				}
			}
		}
	}

	public void activate() {
		Green.SetActive(true);
		Red.SetActive(false);
	}

	public void deactivate() {
		Green.SetActive(false);
		Red.SetActive(true);
	}

	void OnTriggerEnter2D(Collider2D collision) {
		player.GetComponent<Player>().setCurrentCheckpoint(gameObject);
	}

	public override void setPositionRotation(int Col, int Row, int Rot) {
		gameObject.transform.position = new Vector3((float)(Col * 2.5) + 2.5f, (float)(Row * 5) + 2.5f, 0);
	}
}