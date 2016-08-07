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

	void Dock(Rigidbody connectedBody) {
		if (connectedBody != null) {
			
			transform.up = connectedBody.transform.up;
			transform.right = connectedBody.transform.right;
			transform.forward = connectedBody.transform.forward;

			clamp = gameObject.AddComponent<FixedJoint>() as FixedJoint;
			clamp.connectedBody = connectedBody;
		}
	}

	void UnDock() {
		if (clamp != null) {
			Destroy(clamp);
		}
	}
}
