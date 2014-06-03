using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class LevelCreator : MonoBehaviour {

	private GameObject player;

	private string rows;
	private GameObject newObject;

	/* FOR GAMEOBJECT CREATION */
	private Dictionary<char, Func<GameObject>> prefabTypes = new Dictionary<char, Func<GameObject>>(); 
	private Dictionary<string, Color> lightColors = new Dictionary<string, Color>();
	private Dictionary<string, Color> lavaColors = new Dictionary<string, Color>();
	private Dictionary<string, Color> lavaDiffuseColors = new Dictionary<string, Color>();
	private Dictionary<string, Sprite> wallSprites = new Dictionary<string, Sprite>();
	private Dictionary<string, Sprite> lavaSprites = new Dictionary<string, Sprite>();

	/* FOR CREATING WALLS */
	private Sprite wallSprite;
	public GameObject wall;
	
	/* FOR CREATING NON-CLIMBABLE WALLS */
	public GameObject nonClimb;
	
	/* FOR LAVA */
	private Sprite lavaSprite;
	public GameObject lava;
	
	/* FOR SPIKES */
	public GameObject spike;
	
	/* FOR BOUNCE */
	public GameObject bounce;

	/* FOR CHECKPOINTS */
	public GameObject startCheckpoint;
	public GameObject endCheckpoint;
	public GameObject checkpoint;
	
	/* FOR CREATE LEVEL BOX */
	private double widthDouble;
	private double heightDouble;
	
	/* LAVA COLORS */
	private string color;
	private Color lavaColor;
	private Color lavaDiffuseColor;

	void Awake() {
		prefabTypes.Add ('w', ()=>{return (GameObject)Instantiate(wall);});
		prefabTypes.Add ('l', ()=>{return (GameObject)Instantiate(lava);});
		prefabTypes.Add ('n', ()=>{return (GameObject)Instantiate(nonClimb);});
		prefabTypes.Add ('s', ()=>{return (GameObject)Instantiate(spike);});
		prefabTypes.Add ('b', ()=>{return (GameObject)Instantiate(bounce);});
		prefabTypes.Add ('c', ()=>{return (GameObject)Instantiate(checkpoint);});

		lightColors.Add ("red", new Color (255f / 255f, 124f / 255f, 124f / 255f));
		lightColors.Add ("green", new Color (104f / 255f, 240f / 255f, 139f / 255f));
		lightColors.Add ("blue", new Color(159f / 255f, 196f / 255f, 255f / 255f));
		lightColors.Add ("purple", new Color (224f / 255f, 116f / 255f, 248f / 255f));
		lightColors.Add ("yellow", new Color (255f / 255f, 206f / 255f, 101f / 255f));

		lavaColors.Add ("red", new Color(255f/255f, 0f/255f, 0f/255f));
		lavaColors.Add ("green", new Color(0f/255f, 255f/255f, 0f/255f));
		lavaColors.Add ("blue", new Color(0f/255f, 100f/255f, 250f/255f));
		lavaColors.Add ("purple", new Color(250f/255f, 0f/255f, 250f/255f));
		lavaColors.Add ("yellow", new Color(255f/255f, 255f/255f, 0f/255f));

		lavaDiffuseColors.Add ("red", new Color(255f/255f, 133f/255f, 133f/255f));
		lavaDiffuseColors.Add ("green", new Color(146f/255f, 255f/255f, 152f/255f));
		lavaDiffuseColors.Add ("blue", new Color(0f/255f, 244f/255f, 255f/255f));
		lavaDiffuseColors.Add ("purple", new Color(234f/255f, 57f/255f, 193f/255f));
		lavaDiffuseColors.Add ("yellow", new Color(230f/255f, 255f/255f, 0f/255f));

		wallSprites.Add ("red", Resources.Load<Sprite> ("red"));
		wallSprites.Add ("green", Resources.Load<Sprite> ("green"));
		wallSprites.Add ("blue", Resources.Load<Sprite> ("blue"));
		wallSprites.Add ("purple", Resources.Load<Sprite> ("purple"));
		wallSprites.Add ("yellow", Resources.Load<Sprite> ("yellow"));

		lavaSprites.Add ("red", Resources.Load<Sprite> ("redLava"));
		lavaSprites.Add ("green", Resources.Load<Sprite> ("greenLava"));
		lavaSprites.Add ("blue", Resources.Load<Sprite> ("blueLava"));
		lavaSprites.Add ("purple", Resources.Load<Sprite> ("purpleLava"));
		lavaSprites.Add ("yellow", Resources.Load<Sprite> ("yellowLava"));
	}

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");

		//string path = Application.persistentDataPath + "/Maps/" + levelName + ".txt";
		string path = Application.dataPath + "/Maps/Austin.txt";

		try {
			using (StreamReader sr = new StreamReader(path)) {
				rows = sr.ReadLine ();
				double.TryParse(rows, out widthDouble);
				rows = sr.ReadLine ();
				double.TryParse(rows, out heightDouble);
				color = sr.ReadLine ();
				GameObject.Find("Basic_Scene_Light").light.color = lightColors[color];
				lavaColor = lavaColors[color];
				lavaDiffuseColor = lavaDiffuseColors[color];
				lavaSprite = lavaSprites[color];
				wallSprite = wallSprites[color];

				for(int row = 0; row < heightDouble; row++) {
					rows = sr.ReadLine ();
					for(int col = 0; col < widthDouble * 2; col += 2) {
						switch(rows[col]) {
							case 'z': //End Checkpoint
								endCheckpoint.transform.position = new Vector3((float)(col * 2.5) + 2.5f, (float)(row * 5) + 2.5f, 0);
								break;
							case 'w': //Wall
								newObject = prefabTypes[rows[col]].Invoke ();
								newObject.GetComponent<SpriteRenderer>().sprite = wallSprite;
								break;
							case 'l': //Lava
								newObject = prefabTypes[rows[col]].Invoke ();
								newObject.GetComponent<SpriteRenderer>().sprite = lavaSprite;
								newObject.GetComponentInChildren<Light2D>().LightColor = lavaColor;
								newObject.GetComponentInChildren<Light>().color = lavaDiffuseColor;
								break;
							case 'a': //Start Checkpoint
								startCheckpoint.GetComponent<LevelObject>().setPositionRotation(col, row, 0);
								player.transform.position = startCheckpoint.transform.position;
								break;
							case 'n': //Nonclimb Wall
							case 's': //Spike
							case'b': //Bounce
							case 'c': //Checkpoint 
								newObject = prefabTypes[rows[col]].Invoke ();
								break;
						}
						if(rows[col] != '0' && rows[col] != 'a' && rows[col] != 'z') {
							switch(rows[col + 1]) {
								case '0':
									newObject.GetComponent<LevelObject>().setPositionRotation(col, row, 0);
									break;
								case '1':
									newObject.GetComponent<LevelObject>().setPositionRotation(col, row, 1);
									break;
								case '2':
									newObject.GetComponent<LevelObject>().setPositionRotation(col, row, 2);
									break;
								case '3':
									newObject.GetComponent<LevelObject>().setPositionRotation(col, row, 3);
									break;
							}
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			print (e.Message);
			print (e.StackTrace);
		}
	}
}