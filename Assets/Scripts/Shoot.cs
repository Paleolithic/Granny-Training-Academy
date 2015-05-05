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
	public GameObject fpc;

	public bool isFinished;

	RaycastHit hitInfo;
	int triggerLayerIgnore;
	//private Vector3 targetAngles;

	// Use this for initialization
	void Start () 
	{
		speed = 4000;
		MainCamera.enabled = true; 
		ScopeCamera.enabled = false; 
		muzzleTimer = 0.05f;
		shot = false;
		MuzzleFlashObj.SetActive(false);
		fpc = GameObject.Find ("First Person Controller");
		isFinished = false;
		triggerLayerIgnore = 1 << 8;
		triggerLayerIgnore = ~triggerLayerIgnore;
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
			if (isFinished == false)
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

			//RAYCASTING
			if (MainCamera.enabled) {
				Ray ray = MainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
				if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, triggerLayerIgnore)) {
					Debug.DrawLine(ray.origin, hitInfo.point);
					if (hitInfo.collider.gameObject.tag == "cutOut")
					{
						hitInfo.collider.gameObject.GetComponent<CutoutController> ().beenShot = true;
					}
				}
			}
			if (ScopeCamera.enabled) {
				Ray ray = ScopeCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
				if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, triggerLayerIgnore)) {
					Debug.DrawLine(ray.origin, hitInfo.point);
					if (hitInfo.collider.gameObject.tag == "cutOut")
					{
						hitInfo.collider.gameObject.GetComponent<CutoutController> ().beenShot = true;
					}
				}
			}
		}
		if (Input.GetMouseButtonDown (1)) 
		{
			MainCamera.enabled = !MainCamera.enabled;
			ScopeCamera.enabled = !ScopeCamera.enabled;
		}

		if (ScopeCamera.enabled) 
		{
			fpc.GetComponent<MouseLook>().sensitivityX = 1;
			MainCamera.GetComponent<MouseLook>().sensitivityY = 1;
		}

	
	}

}
