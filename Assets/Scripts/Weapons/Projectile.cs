using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour {

	[HideInInspector]
	public float speed;

	[HideInInspector]
	public float range;

	[HideInInspector]
	public float damage;

	Vector3 startPosition;
	Rigidbody rb;

	void Start() {
		startPosition = transform.position;
		rb = GetComponent<Rigidbody> ();
		rb.velocity += transform.forward * speed;
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.magnitude >= (startPosition).magnitude + range) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter(Collision target) {
		// Add damage to the target
		Destroy (gameObject);
	}
}
