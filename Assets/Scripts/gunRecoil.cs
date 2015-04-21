using UnityEngine;
using System.Collections;

public class gunRecoil : MonoBehaviour {

	public float recoil = 0.0f;
	float maxRecoil_x = 20f;
	float recoilSpeed = 2f;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {


		if (recoil > 0f) {
			transform.localRotation = Quaternion.Slerp (transform.localRotation, Quaternion.Euler (maxRecoil_x, 180f, 0f), Time.deltaTime * recoilSpeed);
			recoil -= Time.deltaTime;
		} else {
			recoil = 0f;
			transform.localRotation = Quaternion.Slerp (transform.localRotation, Quaternion.Euler (0f, 180f, 0f), Time.deltaTime * recoilSpeed * 5);
		}
	}
}
