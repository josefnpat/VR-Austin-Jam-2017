using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellableArea : MonoBehaviour {

	public GameObject dispCounterTarget;
	public GameObject magicBoxTarget;


	// Use this for initialization
	void Start () {
		//DispenserCounter dispCounter = gameObject.GetComponentInParent( typeof( DispenserCounter ) ) as DispenserCounter;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider col) {
		
		if (col.gameObject.tag == "Money") {
			
			MagicBox mb = magicBoxTarget.GetComponent<MagicBox>();
			mb.deleteMoney (col.gameObject);

			DispenserCounter dispCounter = dispCounterTarget.GetComponent<DispenserCounter> ();
			dispCounter.increment();
			//dispCounter.counter++;
		}
	}

}
