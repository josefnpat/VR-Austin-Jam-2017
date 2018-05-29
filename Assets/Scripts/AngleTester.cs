using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleTester : MonoBehaviour {

	public Transform testVector;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (Vector3.SignedAngle (testVector.forward, transform.position - testVector.position, Vector3.up));
	}
}
