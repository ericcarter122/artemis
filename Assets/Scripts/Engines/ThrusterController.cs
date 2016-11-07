using UnityEngine;
public static class ThrusterController {
    public static void ApplyForce(Rigidbody rb, Vector3 input, Thruster[] thrusters, float threshold = -0.5F) {
        for (int i = 0; i < thrusters.Length; i++) {
			if (Vector3.Dot(input.normalized, thrusters[i].transform.forward.normalized) < threshold) {
				thrusters[i].AddForce(rb, input.magnitude);
			}
		}
    }

    public static void ApplyTorque(Rigidbody rb, Vector3 input, Thruster[] thrusters, float threshold = 0.5F) {
        for (int i = 0; i < thrusters.Length; i++) {
            Vector3 dist = thrusters[i].transform.position - rb.;
            Vector3 cross = Vector3.Cross(dist, thrusters[i].transform.forward);

            thrusters[i].AddForce(rb, input.magnitude - cross.magnitude);
		}
    }
}