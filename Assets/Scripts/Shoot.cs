using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public Rigidbody projectile;
	float speed;

	//private Vector3 targetAngles;

	// Use this for initialization
	void Start () 
	{
		speed = 900;

	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Input.GetMouseButtonDown (0)) 
		{
			//Creates rigidbody object from prefab
			Rigidbody clone = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;

			//targetAngles = transform.eulerAngles + 180f * Vector3.up; // what the new angles should be
			//clone.transform.eulerAngles = Vector3.Lerp(clone.transform.eulerAngles, targetAngles, Time.deltaTime); // lerp to new angles

			//Pushed the object foward with forces
			clone.AddForce(transform.forward * speed);
		}
	}

}
