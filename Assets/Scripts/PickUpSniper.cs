using UnityEngine;
using System.Collections;

public class PickUpSniper : MonoBehaviour {

	public GameObject pistolSpawn;
	public GameObject pistol;
	public GameObject sniperSpawn;
	public GameObject sniper;
	bool enter;
	GUIStyle fontDetails;
	bool pickedUp;

	// Use this for initialization
	void Start () 
	{
		enter = false;
		fontDetails = new GUIStyle ();
		fontDetails.normal.textColor = Color.white;
		fontDetails.fontSize = 70;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown ("y") && enter) {
			pistolSpawn.SetActive(false);
			pistol.SetActive(false);
			sniperSpawn.SetActive(true);
			sniper.SetActive(true);
			this.gameObject.SetActive(false);
		}
	}

	void OnGUI()
	{
		if (enter) {
			GUI.Label (new Rect (Screen.width / 2 - 400, Screen.height / 2 + 100, 800, 160), "Press Y to pick up sniper.", fontDetails);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			enter = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			enter = false;
		}
	}
}
