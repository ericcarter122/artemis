using UnityEngine;
using System.Collections;

public class MagneticLock : MonoBehaviour {

	FixedJoint clamp;

	void OnTriggerEnter(Collider trigger) {
		if (trigger.tag == "Dockable") {
			Rigidbody rb = trigger.gameObject.GetComponent<Rigidbody>() as Rigidbody;
			Dock(rb);
		}
	}

	void Dock(Rigidbody rb) {
		clamp = gameObject.AddComponent<FixedJoint>() as FixedJoint;
		clamp.connectedBody = rb;
	}

	void UnDock() {
		if (clamp != null) {
			Destroy(clamp);
		}
	}
}
