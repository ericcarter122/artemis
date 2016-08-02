using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof(Radar))]
public class RadarEditor : Editor {

	public float range;

	void OnSceneGUI() {
		Radar radar = (Radar)target;
		Handles.color = Color.green;
		Handles.DrawWireArc(radar.transform.position, Vector3.up, Vector3.forward, 360, radar.range);

		foreach (Transform radarTarget in radar.radarTargets) {
			if (radarTarget != null) {
				Handles.DrawLine (radar.transform.position, radarTarget.position);
			}
		}
	}
}
