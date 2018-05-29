using UnityEngine;
using System.Collections;

public class GroupSpawner : MonoBehaviour
{
	public string spawnString;
	private AudioSource spawnAudioSource;
	public AudioClip spawnAudioClip;

	private DispenserCounter dispCounter;

	private Object[] spawnModels;

	private void Start()
	{
		dispCounter = gameObject.GetComponentInParent( typeof( DispenserCounter ) ) as DispenserCounter;
		dispCounter.addSpawn( this );
		spawnString = dispCounter.spawnerType;

		spawnAudioSource = gameObject.AddComponent<AudioSource>();
		spawnAudioSource.clip = spawnAudioClip;
		spawnModels = Resources.LoadAll( spawnString, typeof( GameObject ) );
		
	}

	public void BuildObject()
	{
		
		if( dispCounter.counter > 1 )
		{
			GameObject objectToSpawn = (GameObject)spawnModels[Random.Range( 0, spawnModels.Length )];
			Instantiate( objectToSpawn, gameObject.transform.position, Quaternion.identity );
			spawnAudioSource.Play();
			dispCounter.counter -= 1;
		}

	}
}
