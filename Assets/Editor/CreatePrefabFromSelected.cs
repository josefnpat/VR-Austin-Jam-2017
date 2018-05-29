using UnityEditor;
using UnityEngine;
using System.Collections;

class CreatePrefabFromSelected : ScriptableObject
{
	const string menuTitle = "GameObject/Create Prefab From Selected";

	/// <summary>
	/// Creates a prefab from the selected game object.
	/// </summary>
	[MenuItem( menuTitle )]
	static void CreatePrefab()
	{
		var objs = Selection.gameObjects;

		string pathBase = EditorUtility.SaveFolderPanel( "Choose save folder", "Assets", "" );

		if( !string.IsNullOrEmpty( pathBase ) )
		{

			pathBase = pathBase.Remove( 0, pathBase.IndexOf( "Assets" ) ) + "/";

			foreach( var go in objs )
			{
				string localPath = pathBase + go.name + ".prefab";


					createNew( go, localPath );
			}
		}
	}

	static void createNew( GameObject obj, string localPath )
	{
		Object prefab = PrefabUtility.CreatePrefab( localPath, obj );
		//EditorUtility.ReplacePrefab( obj, prefab, ReplacePrefabOptions.ReplaceNameBased );
		AssetDatabase.Refresh();
	}

	/// <summary>
	/// Validates the menu.
	/// </summary>
	/// <remarks>The item will be disabled if no game object is selected.</remarks>
	[MenuItem( menuTitle, true )]
	static bool ValidateCreatePrefab()
	{
		return Selection.activeGameObject != null;
	}
}