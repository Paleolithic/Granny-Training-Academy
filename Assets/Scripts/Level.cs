using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour 
{
	public bool room1;
	public bool room2;
	public bool room3;

	public int enemyKillCount;
	public int civKillCount;

	// Use this for initialization
	void Start () 
	{
		enemyKillCount = 0;
		civKillCount = 0;
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


}
