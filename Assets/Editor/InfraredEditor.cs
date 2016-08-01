using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof(Infrared))]
public class InfraredEditor : Editor {

	public float range;

	void OnSceneGUI() {
		Infrared infrared = (Infrared)target;
		Handles.color = Color.red;
		Handles.DrawWireArc(infrared.transform.position, Vector3.up, Vector3.forward, 360, infrared.range);

		Vector3 viewAngleA = infrared.DirFromAngle(-infrared.viewAngle / 2);
		Vector3 viewAngleB = infrared.DirFromAngle(infrared.viewAngle / 2);

		Handles.DrawLine(infrared.transform.position, infrared.transform.position + viewAngleA * infrared.range);
		Handles.DrawLine(infrared.transform.position, infrared.transform.position + viewAngleB * infrared.range);

		foreach (Transform infraredTarget in infrared.infraredTargets) {
			Handles.DrawLine(infrared.transform.position, infraredTarget.position);
		}
	}
}
