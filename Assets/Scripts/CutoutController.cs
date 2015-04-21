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

	Vector3 downRotation;
	Vector3 popUpRotation;
	float smooth;

	Vector3 leftEndPos;
	Vector3 rightEndPos;
	
	// Use this for initialization
	void Start () {
		animationCase = 0;
		firstHit = true;
		firstTrigger = true;
		beenShot = false;
		//cant be shot until triggered
		gameObject.collider.enabled = false;

		downRotation = transform.eulerAngles;
		popUpRotation = new Vector3 (downRotation.x - 90, downRotation.y, downRotation.z);
		smooth = 2.0f;

		leftEndPos = transform.position + transform.right*-2f;
		rightEndPos = transform.position + transform.right*2f;

		if (popUp) {
			animationCase = 1;
		} else if (slideLeft) {
			downRotation = new Vector3(transform.eulerAngles.x + 90, transform.eulerAngles.y, transform.eulerAngles.z);
			animationCase = 2;
		} else if (slideRight) {
			downRotation = new Vector3(transform.eulerAngles.x + 90, transform.eulerAngles.y, transform.eulerAngles.z);
			animationCase = 3;
		}


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
		transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, popUpRotation, Time.deltaTime * smooth * 7);
	}
	
	void slideLeftAnim () {
		transform.position = Vector3.Lerp (transform.position, leftEndPos , Time.deltaTime * smooth);
	}

	void slideRightAnim () {
		transform.position = Vector3.Lerp (transform.position, rightEndPos , Time.deltaTime * smooth);
	}
	
	void beenShotAnim () {
		enterTrigger = false;
		transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, downRotation, Time.deltaTime * smooth * 10);
	}
}
