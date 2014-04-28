using UnityEngine;
using System.Collections;

public class MyUnitySingleton : MonoBehaviour {
	
	private static MyUnitySingleton instance = null;
	public AudioClip intro;
	public AudioClip gameplay;

	public static MyUnitySingleton Instance 
	{
		get { return instance; }
	}

	void Awake() 
	{
		if (instance != null && instance != this) 
		{
			Destroy(this.gameObject);
			return;
		} 
		else 
		{
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}


	void Update()
	{

		//for loading level music
		if((Application.loadedLevelName == "Red"||
		    Application.loadedLevelName == "Yellow"||
		    Application.loadedLevelName == "Green"||
		    Application.loadedLevelName == "Blue"||
		    Application.loadedLevelName =="Purple")
		   && audio.clip == intro)
		{
			audio.clip = gameplay;
			audio.Play();
		}

		//for loading intro and endgame music
		else if((Application.loadedLevelName == "end_screen"||
		    Application.loadedLevelName == "main_menu")
		   && audio.clip == gameplay)
		{
			audio.clip = intro;
			audio.Play();
		}

		if (Input.GetKey (KeyCode.Escape)) 
		{
			if(Application.loadedLevelName != "main_menu")
				Application.LoadLevel("main_menu");
			else Application.Quit ();
		}
	}
}