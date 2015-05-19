using UnityEngine;
using System.Collections;

public class DoorObject : MonoBehaviour {

	float smooth;
	Vector3 originalPosition;
	bool locked = true;

	// Use this for initialization
	void Start () {
		smooth = 2.0f;
		originalPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//room 1 is always unlocked and openable
		if (transform.parent.transform.parent.GetComponent<Level>().room1Door == true) {
			//animation
			if (transform.parent.GetComponent<Door>().enter) {
				transform.position = Vector3.Lerp (transform.position, new Vector3(originalPosition.x, originalPosition.y + 5, originalPosition.z) , Time.deltaTime * smooth);
			} else {
				transform.position = Vector3.Lerp (transform.position, originalPosition , Time.deltaTime * smooth);
			}
		} 
		// room 2 is locked until level 1 : 3 stars
		else if (transform.parent.transform.parent.GetComponent<Level>().room2Door == true) {
			//check stars
			if (GameObject.Find("Left-Level-1").GetComponent<Level>().level2Unlock)
			{
				locked = false;
				//animation
				if (transform.parent.GetComponent<Door>().enter) {
					transform.position = Vector3.Lerp (transform.position, new Vector3(originalPosition.x, originalPosition.y + 5, originalPosition.z) , Time.deltaTime * smooth);
				} else {
					transform.position = Vector3.Lerp (transform.position, originalPosition , Time.deltaTime * smooth);
				}
			}
		} 
		// room 3 is locked until level 2 : 3 stars
		else if (transform.parent.transform.parent.GetComponent<Level>().room3Door == true) {
			//check stars
			if (GameObject.Find("Middle-Level-2").GetComponent<Level>().level3Unlock)
			{
				locked = false;
				//animation
				if (transform.parent.GetComponent<Door>().enter) {
					transform.position = Vector3.Lerp (transform.position, new Vector3(originalPosition.x, originalPosition.y + 5, originalPosition.z) , Time.deltaTime * smooth);
				} else {
					transform.position = Vector3.Lerp (transform.position, originalPosition , Time.deltaTime * smooth);
				}
			}
		}



	}

	void OnGUI () {
		if (transform.parent.GetComponent<Door> ().enter) {
			if (transform.parent.transform.parent.GetComponent<Level>().room2Door == true) {
				if (locked) {
					GUI.Label (new Rect (Screen.width / 2 - 135, Screen.height / 2 + 60, 350, 60), "Complete Level 1 with 3 stars to unlock Level 2.");
				}
			} else if (transform.parent.transform.parent.GetComponent<Level>().room3Door == true) {
				if (locked) {
					GUI.Label (new Rect (Screen.width / 2 - 135, Screen.height / 2 + 60, 350, 60), "Complete Level 2 with 3 stars to unlock Level 3.");
				}
			}
		}
	}
}
