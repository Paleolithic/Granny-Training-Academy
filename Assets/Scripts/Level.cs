using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour 
{
	public bool room1;
	public bool room2;
	public bool room3;

	GUIStyle fontDetails;
	bool enter;

	public int enemyKillCount;
	public int civKillCount;

	// Use this for initialization
	void Start () 
	{
		enter = false;
		fontDetails = new GUIStyle ();
		fontDetails.normal.textColor = Color.white;
		fontDetails.fontSize = 20;
		enemyKillCount = 0;
		civKillCount = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//If the player entered the first room
		if (room1 && enter) 
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
		if(enter)
		{
			//GUI.DrawTexture(new Rect(Screen.width - 405, 5, 150, 100), clock, ScaleMode.ScaleToFit, true, 0.0f);
			GUI.Label(new Rect(Screen.width - 350, 50, 350, 60), "WORKING", fontDetails);
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
