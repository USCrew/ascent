using UnityEngine;
using System.Collections;

public class EditorCamera : MonoBehaviour {

	public Material lineMaterial;
	private float width;
	private float height;
	private bool draw = false;

	/* FOR CAMERA BOUNDS */
	private Plane[] planes;
	private Plane viewingBounds;

	// Use this for initialization
	void Start () {
		gameObject.transform.position = new Vector3 (Camera.main.orthographicSize * (Screen.width - 200)/Screen.height, Camera.main.orthographicSize, -10);
	}

	// Update is called once per frame
	void Update () {}

	void LateUpdate() {
		if (draw) {
			if (Input.GetKey ("up")) {
				gameObject.transform.Translate (new Vector3 (0, 1, 0));
				if(gameObject.transform.position.y >= (height * 5) - Camera.main.orthographicSize + 1) gameObject.transform.Translate (new Vector3(0,-1,0));
			
			}
			if (Input.GetKey ("down")) {
				gameObject.transform.Translate (new Vector3 (0, -1, 0));
				if(gameObject.transform.position.y <= Camera.main.orthographicSize - 1) gameObject.transform.Translate (new Vector3(0,1,0));
				
			}
			if (Input.GetKey ("left")) {
				gameObject.transform.Translate (new Vector3 (-1, 0, 0));
				if(gameObject.transform.position.x <= (Camera.main.orthographicSize * (Screen.width - 200)/Screen.height) - 1) gameObject.transform.Translate (new Vector3(1,0,0));
			}
			if (Input.GetKey ("right")) {
				gameObject.transform.Translate (new Vector3 (1, 0, 0));
				if(gameObject.transform.position.x >= (width * 5) - (Camera.main.orthographicSize * Screen.width/Screen.height) + 1) gameObject.transform.Translate (new Vector3(-1,0,0));
			}

		}
	}

	public void DrawGrid(float w, float h) {
		draw = true;
		width = w;
		height = h;
	}

	void OnPostRender() {
		/* DRAW GRID */
		if(draw) {
			GL.PushMatrix ();
			lineMaterial.SetPass( 0 );
			GL.Begin( GL.LINES );
			GL.Color( Color.white );
			for (int i = 0; i <= width; i++) {
				GL.Vertex3 ((float)(0 + (i * 5)), height * 5f, 0);
				GL.Vertex3 ((float)(0 + (i * 5)), 0f, 0);
			}

			for (int i = 0; i <= height; i++) {
				GL.Vertex3 (0f, (float)(0 + (i * 5)), 0);
				GL.Vertex3 (width * 5f, (float)(0 + (i * 5)), 0);
			}
			GL.End();
			GL.PopMatrix();
		}
	}
}
