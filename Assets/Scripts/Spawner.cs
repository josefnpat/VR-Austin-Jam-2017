using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject objectToSpawn;
	private AudioSource spawnAudioSource;
	public AudioClip spawnAudioClip;

	private void Start(){
		spawnAudioSource = gameObject.AddComponent<AudioSource>();
		spawnAudioSource.clip = spawnAudioClip;

	}

	public void BuildObject() {
		Instantiate(objectToSpawn, gameObject.transform.position, Quaternion.identity);
		spawnAudioSource.Play();
	}
}
