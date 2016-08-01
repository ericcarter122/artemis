using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof(Navigation))]
public class NavigationEditor : Editor {

	void OnSceneGUI() {
		Navigation navigation = (Navigation)target;
		Handles.color = Color.yellow;

		if (navigation.tower != null) {
			Handles.DrawLine(navigation.transform.position, navigation.tower.transform.position);
		}
	}
}
