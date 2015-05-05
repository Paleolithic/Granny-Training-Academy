using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level : MonoBehaviour 
{
	public bool room1;
	public bool room2;
	public bool room3;

	public bool finished;

	public int enemyKillCount;
	public int civKillCount;

	public int enemyTotal;
	public int civTotal;

	public string milliseconds;
	public string seconds;
	public string minutes;

	GUIStyle fontDetails;

	public float totalTime;

	//One Stars
	float oneStarNaziCount;

	//Two Stars
	float twoStarNaziCount;
	float twoStarTimer;
	float twoStarCivCount;

	//Three Stars
	float threeStarNaziCount;
	float threesStarTimer;
	float threeStarCivCount;

	public Texture2D starTexture;
	//public Texture2D darkStarTexture;
	public Texture2D frameTexture;
	int stars;

	public GameObject FPC;
	public GameObject MC;
	public GameObject SC;
	public Camera MCC;
	public GameObject spawn;


	// Use this for initialization
	void Start () 
	{
		room1 = false;
		room2 = false;
		room3 = false;
		enemyKillCount = 0;
		civKillCount = 0;
		finished = false;

		fontDetails = new GUIStyle ();
		fontDetails.normal.textColor = Color.white;
		fontDetails.fontSize = 20;
		stars = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (finished) 
		{

			//If the player entered the first room
			/*if (room1) 
			{
				//One Stars
				oneStarNaziCount = 3;
				
				//Two Stars
				twoStarNaziCount = 9;
				twoStarTimer = 60;
				twoStarCivCount = 3;
				
				//Three Stars
				threeStarNaziCount = 13;
				threesStarTimer = 40;
				threeStarCivCount = 0;

				if(enemyKillCount >= oneStarNaziCount)
				{
					stars = 1;
				}
				if(enemyKillCount >= twoStarNaziCount && civKillCount <= twoStarCivCount && totalTime <= twoStarTimer)
				{
					stars = 2;
				}
				if(enemyKillCount >= threeStarNaziCount && civKillCount <= threeStarCivCount && totalTime <= threesStarTimer)
				{
					stars = 3;
				}



			}*/

			//If the player entered the second room
			if (room2) 
			{
				//One Stars
				oneStarNaziCount = 6;
				
				//Two Stars
				twoStarNaziCount = 13;
				twoStarTimer = 60;
				twoStarCivCount = 3;
				
				//Three Stars
				threeStarNaziCount = 20;
				threesStarTimer = 40;
				threeStarCivCount = 0;
				
				if(enemyKillCount >= oneStarNaziCount)
				{
					stars = 1;
				}
				if(enemyKillCount >= twoStarNaziCount && civKillCount <= twoStarCivCount && totalTime <= twoStarTimer)
				{
					stars = 2;
				}
				if(enemyKillCount >= threeStarNaziCount && civKillCount <= threeStarCivCount && totalTime <= threesStarTimer)
				{
					stars = 3;
				}

			}

			//If the player entered the third room
			else if (room3) 
			{

			}
		}

	}

	void OnGUI()
	{
		if (room1 || room2 || room3 && !finished) 
		{
			GUI.Label (new Rect (Screen.width - 350, 50, 350, 60), minutes + " : " + seconds + " . " + milliseconds, fontDetails);
			GUI.Label (new Rect (Screen.width - 350, 80, 350, 60), "Enemies: " + enemyKillCount + " / " + enemyTotal, fontDetails);
			GUI.Label (new Rect (Screen.width - 350, 110, 350, 60), "Civilians: " + civKillCount + " / " + civTotal, fontDetails);
		}
		if (finished) 
		{
			//Freeze Camera and Movement
			FPC.GetComponent<MouseLook>().enabled = false;
			FPC.GetComponent<CharacterMotor>().enabled = false;
			if (MCC.enabled)
			{
				MC.GetComponent<MouseLook>().enabled = false;
			}
			else
			{
				SC.GetComponent<MouseLook>().enabled = false;
			}
			//Freeze Shooting
			spawn.GetComponent<Shoot>().isFinished = true;

			//Frame
			GUI.DrawTexture (new Rect (Screen.width / 2 - 396, Screen.height / 2 - 324, 792, 648), frameTexture, ScaleMode.StretchToFill, true, 0F);

			//Text
			if(minutes == "0")
			{
				GUI.Label (new Rect (Screen.width / 2 + 145, Screen.height / 2 + 50, 350, 60), seconds + " . " + milliseconds, fontDetails);
			}
			else
			{
				GUI.Label (new Rect (Screen.width / 2 + 125, Screen.height / 2 + 50, 350, 60), minutes + " : " + seconds + " . " + milliseconds, fontDetails);
			}

			GUI.Label (new Rect (Screen.width / 2 + 145, Screen.height / 2 + 140, 350, 60), civKillCount + " / " + civTotal, fontDetails);
			GUI.Label (new Rect (Screen.width / 2 + 145, Screen.height / 2 + 230, 350, 60), enemyKillCount + " / " + enemyTotal, fontDetails);


			//Stars
			if (stars == 1) 
			{
				GUI.DrawTexture (new Rect (Screen.width / 2 - 165, Screen.height / 2 - 90, 90, 90), starTexture, ScaleMode.ScaleToFit, true, 0F);
			}
			if (stars == 2) 
			{
				GUI.DrawTexture (new Rect (Screen.width / 2 - 165, Screen.height / 2 - 90, 90, 90), starTexture, ScaleMode.ScaleToFit, true, 0F);
				GUI.DrawTexture (new Rect (Screen.width / 2 - 22, Screen.height / 2 - 90, 90, 90), starTexture, ScaleMode.ScaleToFit, true, 0F);
			}
			if (stars == 3) 
			{
				GUI.DrawTexture (new Rect (Screen.width / 2 - 165, Screen.height / 2 - 90, 90, 90), starTexture, ScaleMode.ScaleToFit, true, 0F);
				GUI.DrawTexture (new Rect (Screen.width / 2 - 22, Screen.height / 2 - 90, 90, 90), starTexture, ScaleMode.ScaleToFit, true, 0F);
				GUI.DrawTexture (new Rect (Screen.width / 2 + 122, Screen.height / 2 - 90, 90, 90), starTexture, ScaleMode.ScaleToFit, true, 0F);
			}
		}


	}


}
