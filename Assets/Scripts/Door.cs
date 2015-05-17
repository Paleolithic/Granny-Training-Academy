using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	bool enter;
	float smooth;
	Vector3 originalPosition;

	// Use this for initialization
	void Start () {
		enter = false;
		smooth = 2.0f;
		originalPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (enter) {
			transform.position = Vector3.Lerp (transform.position, new Vector3(originalPosition.x, originalPosition.y + 4, originalPosition.z) , Time.deltaTime * smooth);
		} else {
			transform.position = Vector3.Lerp (transform.position, originalPosition , Time.deltaTime * smooth);
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
