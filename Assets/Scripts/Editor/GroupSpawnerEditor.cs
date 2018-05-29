using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(GroupSpawner))]
public class GroupSpawnerEditor : Editor {
	public override void OnInspectorGUI() {
		DrawDefaultInspector();

		GroupSpawner myScript = (GroupSpawner)target;
		if(GUILayout.Button("Build Object Yo")) {
			myScript.BuildObject ();
		}
	}
}