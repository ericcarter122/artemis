using UnityEngine;
public static class ThrusterController {
    public static void ApplyForce(Rigidbody rb, Vector3 input, Thruster[] thrusters, float threshold = -0.5F) {
        
		// Iterate through all thrusters
		for (int i = 0; i < thrusters.Length; i++) {

			// If the thruster is in the direction of the input, we want to fire it
			if (Vector3.Dot(input.normalized, thrusters[i].transform.forward.normalized) <= threshold) {
				// Add force to the thruster equal to the magnitude of the input vector
				thrusters[i].AddForce(rb, input.magnitude);
			}
		}
    }

	// TODO: fix issue where threshold has to be negative (probably why it wiggles)

    public static void ApplyTorque(Rigidbody rb, Vector3 input, Thruster[] thrusters, float threshold = -0.5F) {
        
		// Iterate through all thrusters
		for (int i = 0; i < thrusters.Length; i++) {

			// Get the necessary values to calculate if the thruster can be used to torque around the axis
            Vector3 dist = thrusters[i].transform.position - (rb.transform.position - rb.centerOfMass);
            Vector3 cross = Vector3.Cross(dist, thrusters[i].transform.forward);

			// If the thruster is orthogonal to a direction, use it to create torque in that direction
			if (Vector3.Dot(input.normalized, cross.normalized) <= threshold) {
				// Add force to the thruster equal to the magnitude of the input vector
                thrusters[i].AddForce(rb, input.magnitude);
            }
		}
    }
}