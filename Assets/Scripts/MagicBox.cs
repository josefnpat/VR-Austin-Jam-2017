using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBox : MonoBehaviour {

	public GameObject moneyObjectToSpawn;

	public int initMoney;
	private int targetMoney;
	private int currentMoney;
	private List<GameObject> moneys = new List<GameObject>();
	//public Vector3 moneySpawnLocation;

	public GameObject[] moneySpawnLocations;

	public int randomOffset;

	private AudioSource completeAudioSource;
	public AudioClip completeAudioClip;

	// Use this for initialization
	void Start () {
		targetMoney = initMoney;

		completeAudioSource = gameObject.AddComponent<AudioSource>();
		completeAudioSource.clip = completeAudioClip;

	}
	
	// Update is called once per frame
	void Update () {
		if (targetMoney < 0) {
			targetMoney = 0;
			Debug.Log ("Why do you have negative money? Fixing that for ya, bro.");
		}
		if (targetMoney != currentMoney) {
			if (targetMoney > currentMoney) {
				addMoney ();
			} else if (targetMoney < currentMoney) {
				removeMoney ();
			}
		}

		/*
		foreach (GameObject moneyObj in moneys) {
			if (moneyObj) {
				if (moneyObj.transform.position.y < -5) {
					deleteMoney (moneyObj);
					break; // avoid enum breaking
				}
			}
		}
		*/

	}

	public void setMoney(int value){
		targetMoney = value;
	}
	public int getMoney(){
		return targetMoney;
	}
	public bool changeMoney(int value){
		if (targetMoney + value < 0) {
			Debug.Log ("You don't have that much money!");
			return false;
		}
		targetMoney += value;
		return true;
	}

	public void deleteMoney(GameObject targetMoneyObj){
		currentMoney--;
		moneys.Remove (targetMoneyObj);
		Destroy (targetMoneyObj);
	}

	private void addMoney(){
		currentMoney++;

		GameObject moneySpawnLocation = moneySpawnLocations [Random.Range (0, moneySpawnLocations.Length)];

		GameObject money = Instantiate(moneyObjectToSpawn, moneySpawnLocation.transform.position, Quaternion.identity);
		moneys.Add (money);
		money.transform.Rotate (new Vector3(
			Random.Range(-randomOffset,randomOffset),
			Random.Range(-randomOffset,randomOffset),
			Random.Range(-randomOffset,randomOffset)));
		
	}

	private void removeMoney(){
		if (moneys.Count > 0) {
			deleteMoney (moneys [Random.Range (0, moneys.Count - 1)]);
		} else {
			Debug.Log ("No more money objects. Most likely you didn't check to make sure you can afford it.");
		}
	}

	private int determineObjectValue(GameObject target){
		return 25; // TODO: This is all you, tyler.
	}

	void OnCollisionEnter (Collision col) {

		completeAudioSource.Play ();
		if (col.gameObject.tag == "Money") {
			deleteMoney (col.gameObject);
		} else {
			targetMoney += determineObjectValue (col.gameObject);
			Destroy (col.gameObject);
		}
	}

}
