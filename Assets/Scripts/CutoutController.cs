using UnityEngine;
using System.Collections;

public class CutoutController : MonoBehaviour {
	
	public bool popUp;
	public bool slideLeft;
	public bool slideRight;
	int animationCase;

	public bool beenShot;

	bool firstHit;
	bool enterTrigger;
	bool firstTrigger;

	Vector3 defaultRot;
	Vector3 popUpRotation;
	float smooth;
	
	// Use this for initialization
	void Start () {
		animationCase = 0;
		firstHit = true;
		firstTrigger = true;
		//cant be shot until triggered
		gameObject.collider.enabled = false;

		if (popUp) {
			animationCase = 1;
		} else if (slideLeft) {
			animationCase = 2;
		} else if (slideRight) {
			animationCase = 3;
		}

		defaultRot = transform.eulerAngles;
		popUpRotation = new Vector3 (defaultRot.x - 90, defaultRot.y, defaultRot.z);
		smooth = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.parent.GetComponent<AreaTrigger> ().enter) {
			enterTrigger = true;
		}
		if (beenShot) {
			beenShotAnim();
		
			if (firstHit) {
				//get rid of hitbox (so cant be shot on ground)
				gameObject.collider.enabled = false;
				firstHit = false;
			}
		}
		if (enterTrigger) {
			switch (animationCase)
			{
			case 1:
				popUpAnim();
				break;
			case 2:
				slideLeftAnim();
				break;
			case 3:
				slideRightAnim();
				break;
			}

			if (firstTrigger) {
				//enable hitbox
				gameObject.collider.enabled = true;
				firstTrigger = false;

			}
		}
	}
	
	void popUpAnim () 
	{
		transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, popUpRotation, Time.deltaTime * smooth);
	}
	
	void slideLeftAnim () {

	}

	void slideRightAnim () {
		
	}
	
	void beenShotAnim () {
		enterTrigger = false;
		transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRot, Time.deltaTime * smooth);
	}
}
