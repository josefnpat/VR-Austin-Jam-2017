using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupPhysics : MonoBehaviour {

	private bool rightCanGrab;
	private bool leftCanGrab;
	private bool isRightHeld;
	private bool isLeftHeld;
	private GameObject myRightHand;
	private GameObject myLeftHand;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("HTC_VIU_RightTrigger") > 0 && rightCanGrab) {
			transform.parent = myRightHand.transform;
			isRightHeld = true;
			GetComponent<Rigidbody> ().useGravity = false;
			GetComponent<Rigidbody> ().isKinematic = true;
		}
		if (Input.GetAxis ("HTC_VIU_LeftTrigger") > 0 && leftCanGrab) {
			transform.parent = myLeftHand.transform;
			isLeftHeld = true;
			GetComponent<Rigidbody> ().useGravity = false;
			GetComponent<Rigidbody> ().isKinematic = true;
		}
		if(Input.GetAxis ("HTC_VIU_RightTrigger") == 0 && isRightHeld) {
			transform.parent = null;
			isRightHeld = false;

			GetComponent<Rigidbody> ().isKinematic = false;
			GetComponent<Rigidbody> ().useGravity = true;
			GetComponent<Rigidbody> ().AddForce (myRightHand.GetComponent<HandForce> ().handForce * 5000);
		}		
		if(Input.GetAxis ("HTC_VIU_LeftTrigger") == 0 && isLeftHeld) {
			transform.parent = null;
			isLeftHeld = false;

			GetComponent<Rigidbody> ().isKinematic = false;
			GetComponent<Rigidbody> ().useGravity = true;

			GetComponent<Rigidbody> ().AddForce (myLeftHand.GetComponent<HandForce> ().handForce * 5000);
		}
		rightCanGrab = false;
		leftCanGrab = false;
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "RightHand") {
			myRightHand = other.gameObject;
			rightCanGrab = true;
		}if (other.tag == "LeftHand") {
			myLeftHand = other.gameObject;
			leftCanGrab = true;
		}
	}	

}
