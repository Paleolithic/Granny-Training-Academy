using UnityEngine;
using System.Collections;

public class AreaTrigger : MonoBehaviour {

	public bool enter;

	int enemyKillCount;
	int civKillCount;

	//for area clear prompt?
	public int enemyAreaTotal;
	public int civAreaTotal;
	bool areaClear;
	bool triggerAreaClear;
	GUIStyle fontStyle;
	bool firstTime;


	// Use this for initialization
	void Start () {
		enter = false;
		enemyKillCount = 0;
		civKillCount = 0;

		areaClear = false;
		triggerAreaClear = false;
		//current font style, need seperate for counters and area prompt?
		fontStyle = new GUIStyle ();
		fontStyle.normal.textColor = Color.red;
		firstTime = true;

	}

	public void enemyKill() {
		enemyKillCount += 1;
		//send to level controller (for displaying progress out of total)
		transform.parent.GetComponent<Level>().enemyKillCount += 1;
	}

	public void civKill() {
		civKillCount += 1;
		//send to level controller (for displaying progress out of total)
		transform.parent.GetComponent<Level>().civKillCount += 1;
	}

	// Update is called once per frame
	void Update () {
		//area clear check
		if (enemyKillCount == enemyAreaTotal) {
			areaClear = true;
			triggerAreaClear = true;
		}

		//Check if timer starts and is first time through
		if (this.transform.parent.GetComponent<Level> ().room1 && firstTime) 
		{
			firstTime = false;
			transform.parent.GetComponent<Level> ().enemyTotal += enemyAreaTotal;
			transform.parent.GetComponent<Level> ().civTotal += civAreaTotal;
		}

	}

	void OnGUI() {
		if (areaClear && triggerAreaClear) {
			GUI.Label(new Rect(10, 10, 100, 20), "AREA CLEAR", fontStyle);
			triggerAreaClear = false;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			enter = true;
		}
	}
}
