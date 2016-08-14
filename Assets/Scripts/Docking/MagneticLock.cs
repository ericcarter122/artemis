using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MagneticLock : MonoBehaviour {

	public bool magneticLockEnabled = true;
	public float minimumDockingVelocity;

	[HideInInspector]
	public bool docked = false;

	Rigidbody rb;
	GameObject commonParent;

	Transform connectedBody;
	List<Transform> connectedBodyParents = new List<Transform>();

	float nextToggleMagLock = 0;

	void Start() {
		rb = GetComponent<Rigidbody> ();
	}

	// Controls while docked
	void Update() {

		if (Input.GetKeyDown (KeyCode.G) && Time.time > nextToggleMagLock) {

			float delayTime = 0.5F;

			magneticLockEnabled = !magneticLockEnabled;
			nextToggleMagLock = Time.time + delayTime;
		}

		if (docked && !magneticLockEnabled) {
			UnDock ();
		}
	}

	void OnTriggerEnter(Collider trigger) {
		if (trigger.tag == "Dockable" && !docked && magneticLockEnabled && rb.velocity.magnitude < minimumDockingVelocity) {
			connectedBody = trigger.gameObject.transform;
			Dock (connectedBody);
		}
	}

	void Dock(Transform connectedBody) {
		if (rb != null && connectedBody != null) {

			Transform topParent = AddParents (connectedBody);

			Debug.Log (topParent.name);

			commonParent = new GameObject ();
			transform.parent = commonParent.transform;

			if (topParent == null) {
				connectedBody.parent = commonParent.transform;
			} else {
				topParent.parent = commonParent.transform;
			}
				
			rb.constraints = RigidbodyConstraints.FreezeAll;

			docked = true;
		}
	}

	void UnDock() {

		ResetParents (connectedBody);
		transform.parent = null;

		Destroy (commonParent);

		rb.constraints = RigidbodyConstraints.None;
		docked = false;
	}

	// Returns highest parent in hierarchy of passed in child
	Transform AddParents(Transform child) {

		connectedBodyParents.Clear ();

		Transform t = child;
		while (t.parent != null) {

			connectedBodyParents.Add (t.parent);

			if (t.parent.parent == null) {
				connectedBodyParents.Add (null);
				return t.parent;
			}

			t = t.parent;

		}



		return null;
	}

	void ResetParents(Transform child) {

		Transform t = child;

		for (int i = 0; i < connectedBodyParents.Count; i++) {
			t.parent = connectedBodyParents [i];
			t = t.parent;
		}

		connectedBodyParents.Clear ();

	}

//	IEnumerator LerpDock() {
//
//		Vector3 magLockPosition = magLock.transform.position;
//		Quaternion magLockRotation = magLock.transform.rotation;
//
//		while (transform.position != magLockPosition && transform.rotation != magLockRotation) {
//			Debug.Log ("Ship: " + transform.position + " MagLock: " + magLockPosition);
//			transform.position = Vector3.Lerp (transform.position, magLockPosition, Time.deltaTime);
//			transform.rotation = Quaternion.Lerp (transform.rotation, magLockRotation, Time.deltaTime);
//			yield return null;
//		}
//
//		Debug.Log ("Final = Ship: " + transform.position + " MagLock: " + magLockPosition);
//
//		docked = true;
//	}
//
//	IEnumerator LerpUnDock() {
//		float distance = magLock.bounds.extents.y * 2.5F;
//
//		while (Vector3.Distance (transform.position, magLock.transform.position) < distance) {
//			transform.position = Vector3.Lerp (transform.position, magLock.transform.up * distance, Time.deltaTime);
//			Debug.Log ("undocking");
//			yield return null;
//		}
//
//		docked = false;
//	}
}
