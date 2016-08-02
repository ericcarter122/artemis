using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof(Jammer))]
public class JammerEditor : Editor {

	public float range;

	void OnSceneGUI() {
		Jammer jammer = (Jammer)target;
		Handles.color = Color.cyan;
		Handles.DrawWireArc(jammer.transform.position, Vector3.up, Vector3.forward, 360, jammer.range);

		foreach (GameObject falseTarget in jammer.falseTargets) {
			Handles.DrawWireArc(falseTarget.transform.position, Vector3.up, Vector3.forward, 360, falseTarget.GetComponent<Collider>().bounds.extents.x * 2.0F);
		}
	}
}
