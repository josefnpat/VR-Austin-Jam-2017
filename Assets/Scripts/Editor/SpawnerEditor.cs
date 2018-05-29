using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Spawner))]
public class SpawnerEditor : Editor {
	public override void OnInspectorGUI() {
		DrawDefaultInspector();

		Spawner myScript = (Spawner)target;
		if(GUILayout.Button("Build Object")) {
			myScript.BuildObject();
		}
	}
}