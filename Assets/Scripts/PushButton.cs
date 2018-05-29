using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour {

	private Vector3 startPos;
	private DispenserCounter dispCounter;

	private bool pressed;

	private float pressTimer = 0.5f;

	private AudioSource completeAudioSource;
	public AudioClip completeAudioClip;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
		dispCounter = gameObject.GetComponentInParent( typeof( DispenserCounter ) ) as DispenserCounter;

		completeAudioSource = gameObject.AddComponent<AudioSource>();
		completeAudioSource.clip = completeAudioClip;

	}
	
	// Update is called once per frame
	void Update () {

		if (pressed) {
			pressTimer -= Time.deltaTime;
			if (pressTimer < 0) {
				pressed = false;
				pressTimer = 0.5f;
			}
		}


		if (Vector3.Distance (transform.position, startPos) > 0.1f) {
			//GetComponent<Rigidbody> ().isKinematic = true;
			transform.position = startPos;

			Debug.Log ("Reset");
		}
		 if (transform.position.y < startPos.y - 1.2f) {
			transform.position = new Vector3 (transform.position.x, startPos.y - 1.2f, transform.position.z);
		}

		if (transform.position.y > startPos.y) {
			transform.position = startPos;
		}

		if (transform.position.y < startPos.y) {
			GetComponent<Rigidbody> ().AddForce (transform.worldToLocalMatrix.MultiplyVector(Vector3.up) * Time.deltaTime * 5);
		} else {
			GetComponent<Rigidbody> ().velocity = Vector3.zero;
		}
	}

	void OnTriggerEnter(Collider other){
		if (!pressed && (gameObject.activeInHierarchy && other.tag == "RightHand" || gameObject.activeInHierarchy && other.tag == "LeftHand") && TriggerComplete ()) {
			pressed = true;
			completeAudioSource.Play ();
		}
	}

	public bool TriggerComplete()
	{
		// This is where it should recognize a full crank has occured
		dispCounter.spawnObject();
		return true;
	}
}
