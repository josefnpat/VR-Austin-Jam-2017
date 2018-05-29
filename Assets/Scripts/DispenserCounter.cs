using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DispenserCounter : MonoBehaviour {

	public int counter = 0;
	private int oldCounter = -1;
	public string spawnerType = "Basic";
	private GroupSpawner spawner;
	public Text targetMoneyText;
	public GameObject targetSpawnArea;

	// Use this for initialization
	void Start () {
		
	}

	public void addSpawn( GroupSpawner spawn )
	{
		spawner = spawn;
	}

	public bool increment()
	{
		if (counter >= 99) {
			return false;
		}
		counter++;
		return true;
	}

	public bool decrement(){
		if (counter <= 0) {
			return false;
		}
		counter--;
		return true;
	}

	public void spawnObject()
	{
		decrement ();
		targetSpawnArea.GetComponent<GroupSpawner> ().BuildObject ();
		// todo: make stuff
	}
	// Update is called once per frame
	void Update () {
		if (counter != oldCounter) {
			oldCounter = counter;
			targetMoneyText.text = "$"+counter.ToString();
		}
	}
}
