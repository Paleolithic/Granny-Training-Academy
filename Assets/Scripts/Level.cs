using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level : MonoBehaviour 
{
	public bool room1;
	public bool room2;
	public bool room3;

	public int enemyKillCount;
	public int civKillCount;

	public int enemyTotal;
	public int civTotal;

	public string milliseconds;
	public string seconds;
	public string minutes;

	GUIStyle fontDetails;

	// Use this for initialization
	void Start () 
	{
		room1 = false;
		room2 = false;
		room3 = false;
		enemyKillCount = 0;
		civKillCount = 0;

		fontDetails = new GUIStyle ();
		fontDetails.normal.textColor = Color.white;
		fontDetails.fontSize = 20;
	}
	
	// Update is called once per frame
	void Update () 
	{

		//If the player entered the first room
		if (room1) 
		{

		}

		//If the player entered the second room
		else if (room2) 
		{

		}

		//If the player entered the third room
		else if (room3) 
		{

		}

	}

	void OnGUI()
	{
		if (room1 || room2 || room3) 
		{
			GUI.Label (new Rect (Screen.width - 350, 50, 350, 60), minutes + " : " + seconds + " . " + milliseconds, fontDetails);
			GUI.Label (new Rect (Screen.width - 350, 80, 350, 60), "Enemies: " + enemyKillCount + " / " + enemyTotal, fontDetails);
			GUI.Label (new Rect (Screen.width - 350, 110, 350, 60), "Civilians: " + civKillCount + " / " + civTotal, fontDetails);
		}
	}


}
