using UnityEngine;
using System.Collections;

public class StartTimer : MonoBehaviour 
{
	public bool isFinished;
	GUIStyle fontDetails;
	bool enter;
	string minutes;
	string seconds;
	string milliseconds;
	float minutesf;
	float secondsf;
	float millisecondsf;
	float startTime;

	// Use this for initialization
	void Start () 
	{
		isFinished = false;
		enter = false;
		fontDetails = new GUIStyle ();
		fontDetails.normal.textColor = Color.white;
		fontDetails.fontSize = 20;
		startTime = Time.time;
		minutesf = 0f;
		secondsf = 0f;
		millisecondsf = 0f;

	}
	
	// Update is called once per frame
	void Update () 
	{
		/*millisecondsf -= (startTime - Time.time) * 100;

		if((startTime - Time.time) % 60 == 0)
		{
			minutesf += 1.0f;
		}

		minutes = Time.time.ToString();*/
		if (enter) 
		{
			if (millisecondsf >= 100) 
			{
				if (secondsf >= 59) 
				{
					minutesf++;
					secondsf = 0;
				} else if (secondsf <= 59) 
				{
					secondsf++;
				}
			
				millisecondsf = 0;
			}
		
			millisecondsf += Time.deltaTime * 100;

			minutes = minutesf.ToString ();
			seconds = secondsf.ToString ();
			if(secondsf < 10)
			{
				seconds = 0 + seconds;
			}
			milliseconds = millisecondsf.ToString ();
			milliseconds = milliseconds.Substring(0, 1);
		}
	}

	void OnGUI()
	{
		if(enter && !isFinished)
		{
			//GUI.DrawTexture(new Rect(Screen.width - 405, 5, 150, 100), clock, ScaleMode.ScaleToFit, true, 0.0f);
			GUI.Label(new Rect(Screen.width - 350, 50, 350, 60), minutes + " : " + seconds + " . " + milliseconds, fontDetails);
		}
		
		//gui label for "TIME: ??:??:??"
		//gui label for "ENEMIES: ? / TOTAL"
		//gui label for "CIVILIANS: ? / TOTAL"
	}
	
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			enter = true;
		}
	}
}
