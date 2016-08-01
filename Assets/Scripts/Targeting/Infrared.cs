using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Infrared : MonoBehaviour {

	public float range;
	
	[Range(0, 360)]
	public float viewAngle;

	public LayerMask infraredMask;
	public LayerMask obstacleMask;

	[HideInInspector]
	public List<Transform> infraredTargets = new List<Transform>();

	void Start() {
		StartCoroutine(FindTargets(0.2F));
	}

	IEnumerator FindTargets(float delay) {
		while (true) {
			yield return new WaitForSeconds(delay);
			FindInfraredTargets();
		}
	}

	void FindInfraredTargets() {
		infraredTargets.Clear();
		Collider[] targets = Physics.OverlapSphere(transform.position, range, infraredMask);

		for (int i = 0; i < targets.Length; i++) {
			Transform target = targets[i].transform;
			Vector3 dirToTarget = (target.position - transform.position).normalized;

			if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2) {
				float disToTarget = Vector3.Distance(transform.position, target.position);

				if (!Physics.Raycast(transform.position, dirToTarget, disToTarget, obstacleMask)) {
					infraredTargets.Add(target);
				}
			}
		}
	}

	public Vector3 DirFromAngle(float angleInDegrees) {
		angleInDegrees += transform.eulerAngles.y;
		return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
	}
}
