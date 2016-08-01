using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Radar : MonoBehaviour {

	public float range;

	public LayerMask radarMask;
	public LayerMask obstacleMask;

	[HideInInspector]
	public List<Transform> radarTargets = new List<Transform>();

	void Start() {
		StartCoroutine(FindTargets(1.0F));
	}

	IEnumerator FindTargets(float delay) {
		while (true) {
			yield return new WaitForSeconds(delay);
			FindRadarTargets();
		}
	}

	void FindRadarTargets() {
		radarTargets.Clear();
		Collider[] targets = Physics.OverlapSphere(transform.position, range, radarMask);

		for (int i = 0; i < targets.Length; i++) {
			Transform target = targets[i].transform;

			Vector3 dirToTarget = (target.position - transform.position).normalized;
			float disToTarget = Vector3.Distance(transform.position, target.position);

			if (!Physics.Raycast(transform.position, dirToTarget, disToTarget, obstacleMask)) {
				radarTargets.Add(target);
			}
		}
	}
}
