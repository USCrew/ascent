using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class LevelEditor : MonoBehaviour {

	private GameObject[,] map;
	private Vector3 worldMousePos;
	private Dictionary<Sprite, string> prefabTypes = new Dictionary<Sprite, string>();
	public bool selected = false;
	private string rows;

	/* FOR CREATING WALLS */
	private int selectionGridInt = 0;
	private string[] selectionStrings = {"Red", "Green", "Blue", "Purple", "Yellow"};
	private Vector3 wallPos;
	private Sprite wallSprite;
	public GameObject wall;

	/* FOR CREATING NON-CLIMBABLE WALLS */
	private Vector3 nonClimbPos;
	private Sprite nonClimbSprite;
	public GameObject nonClimb;

	/* FOR LAVA */
	private Vector3 lavaPos;
	private Sprite lavaSprite;
	public GameObject lava;

	/* FOR SPIKES */
	private Vector3 spikePos;
	private Sprite spikeSprite;
	public GameObject spike;

	/* FOR BOUNCE */
	private Vector3 bouncePos;
	private Sprite bounceSprite;
	public GameObject bounce;

	/* FOR CHECKPOINTS */
	private bool startCreated = false;
	private Vector3 startPos;
	private Sprite startSprite;
	private bool endCreated = false;
	private Vector3 endPos;
	private Sprite endSprite;
	private Vector3 checkpointPos;
	private Sprite checkpointSprite;
	public GameObject checkpoint;

	/* FOR CREATE LEVEL BOX */
	private bool creatingLevel = false;
	private Rect windowRect = new Rect((float)(((float)Screen.width/2f)-150f), 100, 300, 250);
	private string levelName = "";
	private string widthString = "width";
	private string heightString = "height";
	private double widthDouble;
	private double heightDouble;
	private string color;

	/* LIGHT COLORS */
	Color red = new Color(255f/255f, 124f/255f, 124f/255f);
	Color green =  new Color(104f/255f, 240f/255f, 139f/255f);
	Color blue = new Color(159f/255f, 196f/255f, 255f/255f);
	Color purple = new Color(224f/255f, 116f/255f, 248f/255f);
	Color yellow = new Color(255f/255f, 206f/255f, 101f/255f);

	/* LAVA COLORS */
	Color lavaColor;
	Color lavaDiffuseColor;
	Color blueDiffuseLava = new Color(0f/255f, 244f/255f, 255f/255f);
	Color blueLava = new Color(0f/255f, 100f/255f, 250f/255f);
	Color greenDiffuseLava = new Color(146f/255f, 255f/255f, 152f/255f);
	Color greenLava = new Color(0f/255f, 255f/255f, 0f/255f);
	Color purpleDiffuseLava = new Color(234f/255f, 57f/255f, 193f/255f);
	Color purpleLava = new Color(250f/255f, 0f/255f, 250f/255f);
	Color redDiffuseLava = new Color(255f/255f, 133f/255f, 133f/255f);
	Color redLava = new Color(255f/255f, 0f/255f, 0f/255f);
	Color yellowDiffuseLava = new Color(230f/255f, 255f/255f, 0f/255f);
	Color yellowLava = new Color(255f/255f, 255f/255f, 0f/255f);

	void Start() {
		/* LOAD SPRITES */
		nonClimbSprite = Resources.Load<Sprite> ("DontClimb");
		spikeSprite = Resources.Load<Sprite> ("spike");
		bounceSprite = Resources.Load<Sprite> ("Bounce");
		startSprite = Resources.Load<Sprite> ("start");
		endSprite = Resources.Load<Sprite> ("finish");
		checkpointSprite = Resources.Load<Sprite> ("Check");

		prefabTypes.Add (nonClimbSprite, "n");
		prefabTypes.Add (spikeSprite, "s");
		prefabTypes.Add (bounceSprite, "b");
		prefabTypes.Add (startSprite, "a");
		prefabTypes.Add (endSprite, "z");
		prefabTypes.Add (checkpointSprite, "c");
	}
	
	void OnGUI () {
		// Make a background box
		worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		if (!creatingLevel) {
			windowRect = GUI.Window (0, windowRect, DoMyWindow, "Create Level");
		}
		else {

			GUI.Box(new Rect(0,0, 100,Screen.height), "Level Objects");

			if (GUI.Button(new Rect (0, 20, 100, 100), wallSprite.texture)) {
				if(!selected) {
					wallPos = new Vector3(worldMousePos.x, worldMousePos.y, 0);

					wall = (GameObject)Instantiate(wall, wallPos, Quaternion.identity);

					wall.GetComponent<SpriteRenderer>().sprite = wallSprite;
					wall.GetComponent<Wall>().Initialize((float)widthDouble, (float)heightDouble, map, this);
					selected = true;
				}
				else print ("Please place current object before creating another object.");
			}

			if (GUI.Button(new Rect (0, 130, 100, 100), nonClimbSprite.texture)) {
				if(!selected) {
					nonClimbPos = new Vector3(worldMousePos.x, worldMousePos.y, 0);

					nonClimb = (GameObject)Instantiate(nonClimb, nonClimbPos, Quaternion.identity);
					
					nonClimb.GetComponent<SpriteRenderer>().sprite = nonClimbSprite;
					nonClimb.GetComponent<Wall>().Initialize((float)widthDouble, (float)heightDouble, map, this);
					selected = true;
				}
				else print ("Please place current object before creating another object.");
			}

			if (GUI.Button(new Rect (0, 240, 100, 100), lavaSprite.texture)) {
				if(!selected) {
					lavaPos = new Vector3(worldMousePos.x, worldMousePos.y, 0);
					
					lava = (GameObject)Instantiate(lava, lavaPos, Quaternion.identity);
					
					lava.GetComponent<SpriteRenderer>().sprite = lavaSprite;
					lava.GetComponent<Lava>().Initialize((float)widthDouble, (float)heightDouble, map, this);
					lava.GetComponentInChildren<Light2D>().LightColor = lavaColor;
					lava.GetComponentInChildren<Light>().color = lavaDiffuseColor;
					selected = true;
				}
				else print ("Please place current object before creating another object.");
			}

			if (GUI.Button(new Rect (0, 350, 100, 80), spikeSprite.texture)) {
				if(!selected) {
					spikePos = new Vector3(worldMousePos.x, worldMousePos.y, 0);
					
					spike = (GameObject)Instantiate(spike, spikePos, Quaternion.identity);
					
					spike.GetComponent<SpriteRenderer>().sprite = spikeSprite;
					spike.GetComponent<Spike>().Initialize((float)widthDouble, (float)heightDouble, map, this);
					selected = true;
				}
				else print ("Please place current object before creating another object.");
			}

			if (GUI.Button(new Rect (0, 440, 100, 40), bounceSprite.texture)) {
				if(!selected) {
					bouncePos = new Vector3(worldMousePos.x, worldMousePos.y, 0);
					
					bounce = (GameObject)Instantiate(bounce, bouncePos, Quaternion.identity);
					
					bounce.GetComponent<SpriteRenderer>().sprite = bounceSprite;
					bounce.GetComponent<Bounce>().Initialize((float)widthDouble, (float)heightDouble, map, this);
					selected = true;
				}
				else print ("Please place current object before creating another object.");
			}

			if (GUI.Button(new Rect (0, 490, 100, 40), startSprite.texture)) {
				if(!selected) {
					if(!startCreated) {
						startPos = new Vector3(worldMousePos.x, worldMousePos.y, 0);
					
						checkpoint = (GameObject)Instantiate(checkpoint, startPos, Quaternion.identity);
						
						checkpoint.GetComponent<SpriteRenderer>().sprite = startSprite;
						checkpoint.GetComponent<Checkpoint>().Initialize((float)widthDouble, (float)heightDouble, map, this);
						startCreated = true;
						selected = true;
					}
					else print ("You can only create one start point");
				
				}
				else print ("Please place current object before creating another object.");
			}

			if (GUI.Button(new Rect (0, 540, 100, 40), endSprite.texture)) {
				if(!selected){
					if(!endCreated) {
						endPos = new Vector3(worldMousePos.x, worldMousePos.y, 0);
						
						checkpoint = (GameObject)Instantiate(checkpoint, endPos, Quaternion.identity);
						
						checkpoint.GetComponent<SpriteRenderer>().sprite = endSprite;
						checkpoint.GetComponent<Checkpoint>().Initialize((float)widthDouble, (float)heightDouble, map, this);
						endCreated = true;
						selected = true;
					}
					else print ("You can only create one end point");
				}
				else print ("Please place current object before creating another object.");
			}

			if (GUI.Button(new Rect (0, 590, 100, 60), checkpointSprite.texture)) {
				if(!selected) {
					checkpointPos = new Vector3(worldMousePos.x, worldMousePos.y, 0);
					
					checkpoint = (GameObject)Instantiate(checkpoint, checkpointPos, Quaternion.identity);
					
					checkpoint.GetComponent<SpriteRenderer>().sprite = checkpointSprite;
					checkpoint.GetComponent<Checkpoint>().Initialize((float)widthDouble, (float)heightDouble, map, this);
					selected = true;
				}
				else print ("Please place current object before creating another object.");
			}

			if (GUI.Button(new Rect (0, 660, 100, 30), "Submit Level")) {
				if(startCreated) {
					if(endCreated) {
						//string path = Application.persistentDataPath + "/Maps/" + levelName + ".txt";
						string path = Application.dataPath + "/Maps/" + levelName + ".txt";
						//if (!File.Exists(path))
						{
							// Create a file to write to. 
							using (StreamWriter sw = File.CreateText(path))
							{
								sw.WriteLine(widthDouble);
								sw.WriteLine(heightDouble);
								sw.WriteLine(color);
								for(int col = 0; col < heightDouble; col++) {
									rows = "";
									for(int row = 0; row < widthDouble; row++) {
										if(map[row,col] == null) rows += "00";
										else {
											rows += prefabTypes[map[row,col].GetComponent<SpriteRenderer>().sprite];
											if(prefabTypes[map[row,col].GetComponent<SpriteRenderer>().sprite] == "s" || prefabTypes[map[row,col].GetComponent<SpriteRenderer>().sprite] == "b" || prefabTypes[map[row,col].GetComponent<SpriteRenderer>().sprite] == "l") {
												if(map[row,col].GetComponent<LevelObject>().currentRotation == LevelObject.Rotations.down) rows += "0";
												else if(map[row,col].GetComponent<LevelObject>().currentRotation == LevelObject.Rotations.right) rows += "1";
												else if(map[row,col].GetComponent<LevelObject>().currentRotation == LevelObject.Rotations.up) rows += "2";
												else if(map[row,col].GetComponent<LevelObject>().currentRotation == LevelObject.Rotations.left) rows += "3";
											}
											else rows += "0";
										}
									}
									sw.WriteLine(rows);
								}
							}
						}
					}
					else print ("You must create an end checkpoint!");
				}
				else print ("You must create a start checkpoint!");
			}
		}
	}

	void DoMyWindow(int windowID) {
		GUI.Label (new Rect (30, 30, 80, 20), "Level Name:"); 
		levelName = GUI.TextField (new Rect (110, 30, 160, 20), levelName); 

		GUI.Label (new Rect (110, 70, 80, 20), "Level Color"); 
		selectionGridInt = GUI.SelectionGrid (new Rect (30, 90, 240, 60), selectionGridInt, selectionStrings, 3);
		switch(selectionGridInt) {
			case 0:
				wallSprite = Resources.Load<Sprite> ("red");
				GameObject.Find("Basic_Scene_Light").light.color = red;
				lavaSprite = Resources.Load<Sprite> ("redLava");
				lavaDiffuseColor = redDiffuseLava;
				lavaColor = redLava;
				color = "red";
				break;
			case 1:
				wallSprite = Resources.Load<Sprite> ("green");	
				GameObject.Find("Basic_Scene_Light").light.color = green;
				lavaSprite = Resources.Load<Sprite> ("greenLava");
				lavaDiffuseColor = greenDiffuseLava;
				lavaColor = greenLava;
				color = "green";
				break;
			case 2:
				wallSprite = Resources.Load<Sprite> ("blue");
				GameObject.Find("Basic_Scene_Light").light.color = blue;
				lavaSprite = Resources.Load<Sprite> ("blueLava");
				lavaDiffuseColor = blueDiffuseLava;
				lavaColor = blueLava;
				color = "blue";
				break;
			case 3:
				wallSprite = Resources.Load<Sprite> ("purple");	
				GameObject.Find("Basic_Scene_Light").light.color = purple;
				lavaSprite = Resources.Load<Sprite> ("purpleLava");
				lavaDiffuseColor = purpleDiffuseLava;
				lavaColor = purpleLava;
				color = "purple";
				break;
			case 4:
				wallSprite = Resources.Load<Sprite> ("yellow");
				GameObject.Find("Basic_Scene_Light").light.color = yellow;
				lavaSprite = Resources.Load<Sprite> ("yellowLava");
				lavaDiffuseColor = yellowDiffuseLava;
				lavaColor = yellowLava;
				color = "yellow";
				break;
		}

		GUI.Label (new Rect (30, 170, 80, 20), "Level Size:"); 
		widthString = GUI.TextField (new Rect (110, 170, 50, 20), widthString);
		GUI.Label (new Rect (165, 170, 20, 20), "x"); 
		heightString = GUI.TextField (new Rect (180, 170, 50, 20), heightString);

		if (GUI.Button (new Rect (50, 210, 200, 30), "Start!")) {
			if(levelName != "") {
				if(widthString != "width" && heightString != "height")
				{
					double.TryParse (widthString, out widthDouble);
					double.TryParse (heightString, out heightDouble);
					creatingLevel = true;
					Camera.main.GetComponent<EditorCamera>().DrawGrid((float)widthDouble, (float)heightDouble);
					prefabTypes.Add (wallSprite, "w");
					prefabTypes.Add (lavaSprite, "l");
					map = new GameObject[(int)widthDouble,(int)heightDouble];
				}
				else {
					print ("Please enter a valid width and height!");
				}
			}
			else {
				print("Please enter a level name!");
			}
		}
	}
}