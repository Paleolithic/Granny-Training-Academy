using UnityEngine;
using System.Collections;

public class MuzzleFlash : MonoBehaviour {

	float startTime;
	float timer;

	// Use this for initialization
	void Start () {
		timer = 0.05f;
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > startTime + timer) {
			Destroy (this.gameObject);
		}
	}
}
