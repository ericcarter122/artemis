using UnityEngine;
using System.Collections;

public class TowerBeacon : MonoBehaviour {

	public float broadcastFrequency;

	void Start() {
		gameObject.tag = "Beacon";
	}
}
