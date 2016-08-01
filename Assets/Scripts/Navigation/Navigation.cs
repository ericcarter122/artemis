using UnityEngine;
using System.Collections;

public class Navigation : MonoBehaviour {

	public float listeningFrequency;
	public Transform tower;

	void Start() {
		StartCoroutine(GetTower(0.2F));
	}

	IEnumerator GetTower(float delay) {
		while (true) {
			RecieveBroadcast();
			yield return new WaitForSeconds(delay);
		}
	}

    void RecieveBroadcast() {
    	tower = null;
    	GameObject[] beacons = GameObject.FindGameObjectsWithTag("Beacon");

    	foreach (GameObject beacon in beacons) {

    		float broadcastFrequency = beacon.GetComponent<TowerBeacon>().broadcastFrequency;

    		if (Mathf.Approximately(listeningFrequency, broadcastFrequency)) {
    			tower = beacon.transform;
    			break;
    		}
    	}
    }
}
