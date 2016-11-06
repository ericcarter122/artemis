using UnityEngine;
public static class ThrusterController {
    public static void ApplyForce(Rigidbody rb, Vector3 input, Thruster[] thrusters) {
        for (int i = 0; i < thrusters.Length; i++) {
			if (Vector3.Dot(input.normalized, thrusters[i].transform.forward.normalized) < -0.5) {
				thrusters[i].AddForce(rb, input.magnitude);
			}
		}
    }

    public static void ApplyTorque(Rigidbody rb, Vector3 input, Thruster[] thrusters) {

    }
}