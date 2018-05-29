using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullLever : MonoBehaviour {

	private bool canGrab;
	private bool isHeld;
	private GameObject myRightHand;
	private DispenserCounter dispCounter;
	//public Transform temp;

	private AudioSource completeAudioSource;
	public AudioClip completeAudioClip;

	private bool rotationStarted;

	private Vector3 crankStartRot;
	private bool fullRotation;

	// Use this for initialization
	void Start () {
		dispCounter = gameObject.GetComponentInParent( typeof( DispenserCounter ) ) as DispenserCounter;

		completeAudioSource = gameObject.AddComponent<AudioSource>();
		completeAudioSource.clip = completeAudioClip;

		crankStartRot = transform.forward;
	}
	
	// Update is called once per frame
	void Update () {
//		if (!GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Resetting")) {
			if (!fullRotation && Vector3.SignedAngle (crankStartRot, transform.forward, Vector3.right) > 1) {
				rotationStarted = true;
			}

			if (rotationStarted && !fullRotation && Vector3.SignedAngle (crankStartRot, transform.forward, Vector3.right) > 90) {
				rotationStarted = false;
				fullRotation = true;
				if (TriggerComplete ()) {
					fullRotation = false;
				}
				//GetComponent<Animator> ().SetTrigger ("Reset");
			}

		if ((Input.GetAxis ("HTC_VIU_RightTrigger") > 0 || Input.GetAxis ("HTC_VIU_LeftTrigger") > 0) && canGrab) {
				isHeld = true;
				Vector3 lookPos = new Vector3 (transform.position.x, myRightHand.transform.position.y, myRightHand.transform.position.z);
				//lookPos.Normalize ();
				//Vector3.Angle(lookPos,transform.forward)
				//temp.LookAt (lookPos);
				//if (temp.eulerAngles.x < transform.eulerAngles.x) {
				if (Vector3.SignedAngle (transform.forward, lookPos - transform.position, Vector3.right) > 0) {
					transform.LookAt (lookPos);
				}
				//}
			}
			if (Input.GetAxis ("HTC_VIU_RightTrigger") == 0 && Input.GetAxis ("HTC_VIU_LeftTrigger") == 0 && isHeld) {
				isHeld = false;


			}
			canGrab = false;
		//}
	}

	public bool TriggerComplete()
	{
		// This is where it should recognize a full crank has occured
		dispCounter.spawnObject();
		completeAudioSource.Play ();
		return true;
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "RightHand" || other.tag == "LeftHand") {
			myRightHand = other.gameObject;
			canGrab = true;
		}
	}	
}
