using UnityEngine;
using System.Collections;

public class EndTimer : MonoBehaviour 
{
	public GameObject startTrigger;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			startTrigger.GetComponent<StartTimer>().isFinished = true;
			this.transform.parent.GetComponent<Level> ().finished = true;
		}
	}
}
