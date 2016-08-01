using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Targeting))]
public class RadarRender : MonoBehaviour {

	public GameObject blip;

	Targeting targeting;


	float radarRadius;
	Collider radar;

	GameObject[] targets;
	GameObject[] blips;

	// Use this for initialization
	void Start () {
		targeting = GetComponent<Targeting> ();
		radar = GetComponent<Collider> ();
		targets = targeting.targets;
		radarRadius = targeting.radarRadius;
		blips = new GameObject[0];
	}
	
	// Update is called once per frame
	void Update () {

		targets = targeting.targets;
		radarRadius = targeting.radarRadius;

		for (int i = 0; i < blips.Length; i++) {
			Destroy(blips [i]);
		}

		if (targets != null) {
			blips = new GameObject[targets.Length];

			for (int i = 0; i < targets.Length; i++) {

				Vector3 blipPosition = new Vector3 (targets [i].transform.localPosition.x, targets [i].transform.localPosition.z, transform.position.z);

				blipPosition.x *= (radar.bounds.extents.x * 2) / (radarRadius + radar.bounds.extents.x);
				blipPosition.y *= (radar.bounds.extents.y * 2) / (radarRadius + radar.bounds.extents.y);

				blips [i] = Instantiate (blip, blipPosition, transform.rotation) as GameObject;
			}
		}
	}

}
