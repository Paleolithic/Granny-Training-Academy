using UnityEngine;
using System.Collections;

public class DoorObject : MonoBehaviour {

	float smooth;
	Vector3 originalPosition;

	// Use this for initialization
	void Start () {
		smooth = 2.0f;
		originalPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.parent.GetComponent<Door>().enter) {
			transform.position = Vector3.Lerp (transform.position, new Vector3(originalPosition.x, originalPosition.y + 5, originalPosition.z) , Time.deltaTime * smooth);
		} else {
			transform.position = Vector3.Lerp (transform.position, originalPosition , Time.deltaTime * smooth);
		}
	}
}
