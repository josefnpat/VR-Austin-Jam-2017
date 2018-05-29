using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandForce : MonoBehaviour {

	private Vector3 lastFrame;
	public Vector3 handForce;

	// Use this for initialization
	void Start () {
		lastFrame = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		handForce *= 0.5f;
		handForce += transform.position - lastFrame;

		lastFrame = transform.position;
	}
}
