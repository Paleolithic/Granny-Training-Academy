using UnityEngine;
using System.Collections;

public class StartTimer : MonoBehaviour 
{
	public bool isFinished;
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
		startTime = Time.time;
		minutesf = 0f;
		secondsf = 0f;
		millisecondsf = 0f;
	

	}
	
	// Update is called once per frame
	void Update () 
	{
		//If you have entered the tigger and you have not finished the level yet
		if (enter && !isFinished) 
		{
			//Check if its been longer than 100 milliseconds
			if (millisecondsf >= 100) 
			{
				//Check if its been longer than 59 seconds
				if (secondsf >= 59) 
				{
					//Add to minutes if it has been 60 seconds the zero out seconds
					minutesf++;
					secondsf = 0;
				} else if (secondsf <= 59) 
				{
					secondsf++;
				}
			
				millisecondsf = 0;
			}
		    
			//Add to the millisecond counter using deltatime
			millisecondsf += Time.deltaTime * 100;

			//Convert all the floats to strings to print out
			minutes = minutesf.ToString ();
			seconds = secondsf.ToString ();
			//If it has been less than 10 seconds make sure there is a zero in front
			if(secondsf < 10)
			{
				seconds = 0 + seconds;
			}
			milliseconds = millisecondsf.ToString ();
			milliseconds = milliseconds.Substring(0, 1);
		}

		if (enter) 
		{
			this.transform.parent.GetComponent<Level> ().milliseconds = milliseconds;
			this.transform.parent.GetComponent<Level> ().seconds = seconds;
			this.transform.parent.GetComponent<Level> ().minutes = minutes;
		}
	}
	
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			enter = true;
			transform.parent.GetComponent<Level> ().room1 = true;
		}
	}
}
