using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Jammer : MonoBehaviour {

	public float range;
	public int density;
	public float interval;
	public GameObject falseTarget;

	[HideInInspector]
	public List<GameObject> falseTargets;

	void Start() {
		StartCoroutine(JamOnInterval (interval));
	}

	IEnumerator JamOnInterval(float interval) {
		while (true) {
			JamArea ();
			yield return new WaitForSeconds (interval);
		}
	}

	void JamArea() {

		foreach (GameObject clone in falseTargets) {
			Destroy (clone);
		}

		falseTargets.Clear ();

		for (int i = 0; i < density; i++) {

			Vector3 position = (Random.insideUnitSphere * range) + transform.position;

			GameObject clone = Instantiate (falseTarget, position, transform.rotation) as GameObject;
			falseTargets.Add (clone);
		}
	}
}
