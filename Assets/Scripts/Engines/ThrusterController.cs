using UnityEngine;
public static class ThrusterController {

	// For dot product checks on 45 deg angles
	static readonly float THREASHOLD = -0.5F;

    public static void ApplyForce(Rigidbody rb, Vector3 input, Thruster[] thrusters) {
        
		// Iterate through all thrusters
		for (int i = 0; i < thrusters.Length; i++) {

			// If the thruster is in the direction of the input, we want to fire it
			float dot = Vector3.Dot(input.normalized, thrusters[i].transform.forward.normalized);
			if (dot <= THREASHOLD) {
				// Add force to the thruster equal to the magnitude of the input vector
				thrusters[i].AddForce(rb, input.magnitude);
			}
		}
    }

    public static void ApplyTorque(Rigidbody rb, Vector3 input, Thruster[] thrusters) {
        
		// Iterate through all thrusters
		for (int i = 0; i < thrusters.Length; i++) {

			// Get the necessary values to calculate if the thruster can be used to torque around the axis
            Vector3 dist = thrusters[i].transform.position - (rb.transform.position - rb.centerOfMass);
            Vector3 cross = Vector3.Cross(dist, thrusters[i].transform.forward);

			// If the thruster is orthogonal to a direction, use it to create torque in that direction
			float dot = Vector3.Dot(input.normalized, cross.normalized);
			if (dot <= THREASHOLD) {
				// Add force to the thruster equal to the magnitude of the input vector
                thrusters[i].AddForce(rb, input.magnitude);
            }
		}
    }
}