using UnityEngine;
using System.Collections;
using System.IO;

public class MetricManagerScript : MonoBehaviour {
	
	string createText = "";


	public float elapsedTime = 0;
	public int numberDeaths = 0;

	bool playing = false;
	
	void Start () {
		playing = true;
	}

	void Update () {
		if(playing == true) elapsedTime += Time.deltaTime;
	}
	
	//When the game quits we'll actually write the file.
	void OnLevelEnd(){
		GenerateMetricsString ();
		string time = System.DateTime.UtcNow.ToString ();string dateTime = System.DateTime.Now.ToString (); //Get the time to tack on to the file name
		time = time.Replace ("/", "-"); //Replace slashes with dashes, because Unity thinks they are directories..
		string reportFile = "Ascent_Metrics_" + time + ".txt"; 
		File.WriteAllText (reportFile, createText);
		//In Editor, this will show up in the project folder root (with Library, Assets, etc.)
		//In Standalone, this will show up in the same directory as your executable
	}
	
	void GenerateMetricsString(){
		createText = 
			"Current level: " + Application.loadedLevelName + "\n" +
				"Total time to finish level: " + elapsedTime + "\n" +
					"Number of deaths by player: " + numberDeaths;
	}
	
	//Add to your set metrics from other classes whenever you want
	public void AddToNumberDeaths(){
		numberDeaths++;
	}

	void OnTriggerEnter2D(Collider2D collision){
		playing = false;
		OnLevelEnd();
	}
}