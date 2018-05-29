using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glue : MonoBehaviour {

	private float dryingTime = 100;
	private bool touching;
	private bool glued;
	private bool stuck;

	private GameObject[] gluers = new GameObject[5];
	private int gluerCount;

	private int togethers;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (dryingTime > 0) {
			dryingTime -= Time.deltaTime;
		} else {
			glued = true;
			Debug.Log ("Glue Dried");
			for (int i = 0; i < 5; i++) {
				if (gluers [i] != null && gluers [i].GetComponent<Gluable> ().touching) {
					togethers++;
					gluers [i].GetComponent<Gluable> ().ToGlue (transform);
				}
			}
			if (togethers < 2) {
				Destroy (gameObject);
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if (!glued && other.GetComponent<Gluable> () && stuck) {
			gluers [gluerCount] = other.gameObject;
			gluerCount++;
		}
		if (other.tag != "Glue" && other.tag != "GlueBottle" && other.tag != "LeftHand"  && other.tag != "RightHand" && !stuck && other.tag != "dispenser") {
			stuck = true;
			dryingTime = 6;
			GetComponent<Rigidbody> ().isKinematic = true;
			transform.parent = other.transform;
		}
	}
}
