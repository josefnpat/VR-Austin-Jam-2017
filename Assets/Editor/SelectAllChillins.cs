using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SelectAllChillins
{
	/// <summary>
	/// Add a menu item to select all our texts
	/// </summary>
	[MenuItem( "GameObject/SelectAllChil" )]
	private static void SelectAllChilds()
	{

		SelectAllChildren();
	}

	/// <summary>
	/// Allows us to select all children objects by a specific type
	/// </summary>
	/// <typeparam name="T">Type we are searching for, has to be a component</typeparam>
	private static void SelectAllChildren()
	{
		List<Object> newSelection = new List<Object>();
		Transform[] startTransforms = Selection.transforms;

		// use a recursive search to find all children
		foreach( Transform selection in startTransforms )
			foreach( Transform child in selection )
				newSelection.Add( child.gameObject );

		Selection.objects = newSelection.ToArray();
	}

}