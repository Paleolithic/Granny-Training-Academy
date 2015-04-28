using UnityEngine;
using System.Collections;

public class Sprint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftShift)) {
			this.GetComponent<CharacterMotor> ().movement.maxForwardSpeed = 12f;
			this.GetComponent<CharacterMotor> ().movement.maxSidewaysSpeed = 8f;
			this.GetComponent<CharacterMotor> ().movement.maxBackwardsSpeed = 8f;
		} else {
			this.GetComponent<CharacterMotor> ().movement.maxForwardSpeed = 6f;
			this.GetComponent<CharacterMotor> ().movement.maxSidewaysSpeed = 6f;
			this.GetComponent<CharacterMotor> ().movement.maxBackwardsSpeed = 6f;
		}
	}
}
