using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	public float time;
	public bool hitObject;
	public GameObject pic;

	// Use this for initialization
	void Start () 
	{
		//If the gameobject hasnt hit anything for "time" then destroy
		Destroy (this.gameObject, time);
		hitObject = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnCollisionEnter(Collision collision)
	{
		//If the bullet collides with something destroy it
		Destroy (this.gameObject);
		hitObject = true;
		//For Instatiating bulletHole texture..
		//Rigidbody clone = Instantiate(pic, transform.position, transform.rotation) as Rigidbody;


	}
}
