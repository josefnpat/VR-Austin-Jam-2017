using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlueBottle : MonoBehaviour {

	public GameObject top;
	private float dripTimer = 0.3f;

	private AudioSource completeAudioSource;
	public AudioClip[] completeAudioClip;

	// Use this for initialization
	void Start () {
		completeAudioSource = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		dripTimer -= Time.deltaTime;
		if (top.transform.position.y < transform.position.y && dripTimer < 0) {
			PourGlue ();
			dripTimer = 0.3f;
		}
	}

	public void PourGlue()
	{
		int index = Random.Range (0, completeAudioClip.Length);
		completeAudioSource.clip = completeAudioClip[index];
		completeAudioSource.Play ();
		Instantiate (Resources.Load ("Glue"),top.transform.position,top.transform.rotation);
	}
}
