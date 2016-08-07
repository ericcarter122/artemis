using UnityEngine;
using System.Collections;

public class Thruster : MonoBehaviour {

	bool playing = false;

	// Update is called once per frame
	void Update () {
	
		if (Input.GetAxis ("Vertical") > 0 && !playing) {
			StartThruster ();
		} else if (Input.GetAxis ("Vertical") <= 0 && playing) {
			StopThruster ();
		}

	}

	void StartThruster() {
		for (int i = 0; i < transform.childCount; i++) {
			Transform child = transform.GetChild(i);
			ParticleSystem ps = child.GetComponent<ParticleSystem> ();

			ps.Play ();
			playing = true;
		}
	}

	void StopThruster() {
		for (int i = 0; i < transform.childCount; i++) {
			Transform child = transform.GetChild(i);
			ParticleSystem ps = child.GetComponent<ParticleSystem> ();

			ps.Stop ();
			playing = false;
		}
	}
}
