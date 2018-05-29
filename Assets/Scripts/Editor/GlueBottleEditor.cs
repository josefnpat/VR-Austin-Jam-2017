using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(GlueBottle))]
public class GlueBottleEditor : Editor {
	public override void OnInspectorGUI() {
		DrawDefaultInspector();

		GlueBottle myScript = (GlueBottle)target;
		if(GUILayout.Button("make da glue bro")) {
			myScript.PourGlue ();
		}
	}
}