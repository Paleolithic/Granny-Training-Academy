using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public Rigidbody projectile;
	float speed;
	public Camera MainCamera; 
	public Camera ScopeCamera;

	public GameObject MuzzleFlashObj;
	float muzzleStart;
	float muzzleTimer;
	bool shot;

	public GameObject pistolObj;

	//private Vector3 targetAngles;

	// Use this for initialization
	void Start () 
	{
		speed = 900;
		MainCamera.enabled = true; 
		ScopeCamera.enabled = false; 
		muzzleTimer = 0.05f;
		shot = false;
		MuzzleFlashObj.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if ((Time.time > muzzleStart + muzzleTimer) && shot) {
			MuzzleFlashObj.SetActive(false);
			shot = false;
		}



		if (Input.GetMouseButtonDown (0)) 
		{
			pistolObj.GetComponent<gunRecoil>().recoil += 0.1f;
			//Creates rigidbody object from prefab
			Rigidbody clone = Instantiate(projectile, transform.position, this.gameObject.transform.rotation) as Rigidbody;

			//Always facing Z axis
			//clone.transform.rotation = Quaternion.Euler(transform.parent.rotation.x + 90f, transform.parent.rotation.y, transform.parent.rotation.z);

			//Wanted
			clone.transform.parent = this.transform;
			clone.transform.localRotation = Quaternion.Euler(90, 0, 0);

			//Pushed the object foward with forces
			clone.AddForce(transform.forward * speed);

			clone.transform.parent = null;

			muzzleStart = Time.time;
			MuzzleFlashObj.SetActive(true);
			shot = true;
		}
		if (Input.GetMouseButtonDown (1)) 
		{
			MainCamera.enabled = !MainCamera.enabled;
			ScopeCamera.enabled = !ScopeCamera.enabled;
		}


	}

}
