using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gluable : MonoBehaviour {

	public Transform moveWith;

	public bool touching;
	private Transform glues;
	private bool glued;
	public Vector3 moveWithPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (glued && moveWith != null) {
			//transform.Translate (moveWith.position - moveWithPos);
		}
	}

	public void ToGlue(Transform glue)
	{
		Debug.Log ("Item Glued");
		if(GetComponent<Rigidbody> ())
			GetComponent<Rigidbody> ().isKinematic = true;
		transform.parent = glue.parent;
		if(GetComponent<pickupPhysics> ())
			Destroy (GetComponent<pickupPhysics> ());
		if(GetComponent<Rigidbody> ())
			Destroy (GetComponent<Rigidbody> ());
		if (glue.parent != null && glue.parent.GetComponent<Gluable> ()) {
			//glue.parent.GetComponent<Gluable> ().moveWith = transform;
			//glue.parent.GetComponent<Gluable> ().moveWithPos = transform.position;
		}
		glued = true;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Glue") {
			glues = other.transform;
			touching = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Glue") {
			touching = false;
		}
	}
}
