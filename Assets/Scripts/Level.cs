using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level : MonoBehaviour 
{
	public bool room1;
	public bool room2;
	public bool room3;

	public bool room1Door;
	public bool room2Door;
	public bool room3Door;

	public GameObject level2Light;
	public GameObject level3Light;

	public bool finished;

	public int enemyKillCount;
	public int civKillCount;

	public int enemyTotal;
	public int civTotal;

	public string milliseconds;
	public string seconds;
	public string minutes;

	public bool level2Unlock = false;
	public bool level3Unlock = false;

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
	public int stars;

	public GameObject FPC;
	public GameObject MC;
	public GameObject SC;
	public Camera MCC;
	public GameObject spawn;

	GameObject[] cutOutArray;


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
	}
	
	// Update is called once per frame
	void Update () 
	{
		print (stars);
		if (Input.GetKeyDown("i")) {
			level3Unlock = true;
			level3Light.SetActive(true);
		}

		if (finished) 
		{

			//If the player entered the first room
			if (room1) 
			{
				//One Stars
				oneStarNaziCount = 3;
				
				//Two Stars
				twoStarNaziCount = 9;
				twoStarTimer = 60;
				twoStarCivCount = 3;
				
				//Three Stars
				threeStarNaziCount = 12;
				threesStarTimer = 40;
				threeStarCivCount = 0;

				if(enemyKillCount < oneStarNaziCount)
				{
					stars = 0;
				}
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
					level2Unlock = true;
					level2Light.SetActive(true);
				}



			}

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
				threeStarNaziCount = 21;
				threesStarTimer = 40;
				threeStarCivCount = 0;

				if(enemyKillCount < oneStarNaziCount)
				{
					stars = 0;
				}
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
					level3Unlock = true;
					level3Light.SetActive(true);
				}

			}

			//If the player entered the third room
			else if (room3) 
			{
				//One Stars
				oneStarNaziCount = 10;
				
				//Two Stars
				twoStarNaziCount = 39;
				twoStarTimer = 90;
				twoStarCivCount = 10;
				
				//Three Stars
				threeStarNaziCount = 49;
				threesStarTimer = 45;
				threeStarCivCount = 0;
				
				if(enemyKillCount < oneStarNaziCount)
				{
					stars = 0;
				}
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
					level3Unlock = true;
				}
			}





			//END GAME STATE
			if(finished)
			{
				if (Input.GetKeyDown("f")) 
				{
					finished = false;

					//UnFreeze Camera and Movement
					FPC.GetComponent<MouseLook>().enabled = true;
					FPC.GetComponent<CharacterMotor>().enabled = true;
					if (MCC.enabled)
					{
						MC.GetComponent<MouseLook>().enabled = true;
					}
					else
					{
						SC.GetComponent<MouseLook>().enabled = true;
					}
					//UnFreeze Shooting
					spawn.GetComponent<Shoot>().isFinished = false;
					//UnFreeze Scoping
					spawn.GetComponent<Shoot>().able = true;


					//RESET -------------------------------------------------------
					if(room1)
					{
						GameObject level1 = GameObject.Find ("Left-Start-Trigger");
						level1.GetComponent<StartTimer>().Start();

					}
					if(room2)
					{
						GameObject level2 = GameObject.Find ("Middle-Start-Trigger");
						level2.GetComponent<StartTimer>().Start();
					}
					if(room3)
					{
						GameObject level3 = GameObject.Find ("Right-Start-Trigger");
						level3.GetComponent<StartTimer>().Start();
					}

					//Get all cutouts
					cutOutArray = GameObject.FindGameObjectsWithTag("cutOut");
					foreach(GameObject c in cutOutArray)
					{
						c.GetComponent<CutoutController>().Reset();
					}

					GameObject[] areaTriggers = GameObject.FindGameObjectsWithTag("areaTrigger");
					foreach(GameObject a in areaTriggers)
					{
						a.GetComponent<AreaTrigger>().Start();
					}

					Start();
					//Set all rooms to false
					room1 = false;
					room2 = false;
					room3 = false;
					// -------------------------------------------------------------
				}
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
			//Freeze Scoping
			spawn.GetComponent<Shoot>().able = false;


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

			//Draw "Presss F to continue"
			GUI.Label (new Rect (Screen.width / 2 - 60, Screen.height - 185, 350, 60), "Press F to continue", fontDetails);
		}


	}


}
