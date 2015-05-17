using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public bool enter;


	// Use this for initialization
	void Start () {
		enter = false;
	}
	
	// Update is called once per frame
	void Update () {

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
