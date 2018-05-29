using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(MagicBox))]
public class MagicBoxEditor : Editor {
	public override void OnInspectorGUI() {
		DrawDefaultInspector();

		MagicBox myScript = (MagicBox)target;
		if(GUILayout.Button("Set Money to 1000")) {
			myScript.setMoney (1000);
		}

		if(GUILayout.Button("Set Money to 0")) {
			myScript.setMoney (0);
		}
	}
}