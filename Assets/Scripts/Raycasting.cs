using UnityEngine;
using System.Collections;

public class Raycasting : MonoBehaviour {

	public Camera mainCamera;
	public Camera scopeCamera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = camera.ScreenPointToRay(new Vector3(200, 200, 0));
	}
}
