using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(DispenserCounter))]
public class DispenserCounterEditor : Editor {
	public override void OnInspectorGUI() {
		DrawDefaultInspector();

		DispenserCounter myScript = (DispenserCounter)target;
		if(GUILayout.Button("increment")) {
			myScript.increment();
		}
		if(GUILayout.Button("decrement")) {
			myScript.decrement();
		}
		if(GUILayout.Button("spawnObject")) {
			myScript.spawnObject();
		}
	}
}