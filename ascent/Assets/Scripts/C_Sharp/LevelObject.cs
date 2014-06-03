using UnityEngine;
using System.Collections;

public abstract class LevelObject : MonoBehaviour {

	protected GameObject player;

	/* For Rotations */
	public enum Rotations {down, right, up, left};
	public Rotations currentRotation;

	/* FOR MAP EDITOR */
	protected bool game;
	protected bool editor;
	protected bool selected;
	protected Vector3 worldMousePos;
	protected float width;
	protected float height;
	protected GameObject[,] map;
	protected LevelEditor editorScript;

	protected virtual void Awake () {
		editor = false;
		selected = false;
	}

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}

	public void Initialize(float w, float h, GameObject[,] m, LevelEditor mS) {
		editor = true;
		selected = true;
		width = w;
		height = h;
		map = m;
		editorScript = mS;
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		worldMousePos.x = (worldMousePos.x - (worldMousePos.x % 5f));
		worldMousePos.y = (worldMousePos.y - (worldMousePos.y % 5f));
	}

	void OnMouseDown() {
		if (editor) {
			if(selected) {
				if(map[(int)((worldMousePos.x)/5), (int)((worldMousePos.y)/5)] == null) {
					map[(int)((worldMousePos.x)/5), (int)((worldMousePos.y)/5)] = gameObject;
					selected = !selected;
					editorScript.selected = false;
				}
				else {
					print ("This position is taken by another object!");
				}
				
			}
			else if(!selected && !editorScript.selected) {
				map[(int)((worldMousePos.x)/5), (int)((worldMousePos.y)/5)] = null;
				selected = !selected;
				editorScript.selected = true;
			}
		}
	}

	public abstract void setPositionRotation(int Col, int Row, int Rot);

	/* UTILITY FUNCTIONS */
	protected Rotations GetNextRotation(string direction) {
		if (direction == "right") {
			if (currentRotation == Rotations.down)
				return Rotations.right;
			else if (currentRotation == Rotations.right)
				return Rotations.up;
			else if (currentRotation == Rotations.up)
				return Rotations.left;
			else if (currentRotation == Rotations.left)
				return Rotations.down;
		}
		else if(direction == "left") {
			if (currentRotation == Rotations.down)
				return Rotations.left;
			else if (currentRotation == Rotations.left)
				return Rotations.up;
			else if (currentRotation == Rotations.up)
				return Rotations.right;
			else if (currentRotation == Rotations.right)
				return Rotations.down;
		}
		return Rotations.down;
	}
}