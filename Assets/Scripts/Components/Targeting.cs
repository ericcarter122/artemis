using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Targeting : MonoBehaviour {

	public LayerMask layerMask;

    [Range(0.0F, 1000.0F)]
    public float radarRadius;

	public GameObject[] targets { get; set; }
	public GameObject target { get; set; }

	// Use this for initialization
	void Start () {
		targets = new GameObject[0];
    }

	void FixedUpdate() {
		
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, radarRadius);
		targets = new GameObject[hitColliders.Length];

        for (int i = 0; i < hitColliders.Length; i++) {
            targets[i] = hitColliders[i].gameObject;
        }
    }

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (transform.position, radarRadius);
	}
}
