using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	public float time;
	public GameObject pic;

	// Use this for initialization
	void Start () 
	{
		//If the gameobject hasnt hit anything for "time" then destroy
		Destroy (this.gameObject, time);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnCollisionEnter(Collision collision)
	{
		//If the bullet collides with something destroy it
		//if (collision.gameObject.tag == "cutOut") {
		//	collision.gameObject.GetComponent<CutoutController> ().beenShot = true;
		//}

		//For Instatiating bulletHole texture..
		//GameObject clone = Instantiate (pic, transform.position, transform.rotation) as GameObject;
		//clone.transform.parent = collision.gameObject.transform;
		Destroy (this.gameObject);

	}
}
