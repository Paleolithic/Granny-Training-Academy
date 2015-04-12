using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public Rigidbody projectile;
	float speed;

	// Use this for initialization
	void Start () 
	{
		speed = 2000;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			//Creates rigidbody object from prefab
			Rigidbody clone = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
			//Pushed the object foward with forces
			clone.AddForce(transform.forward * speed);
		}
	}

}
