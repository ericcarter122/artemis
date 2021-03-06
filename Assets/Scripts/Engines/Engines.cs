﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Engines : MonoBehaviour {

	public Thruster[] thrusters;

	public float maxSpeed, maxAngularSpeed;

	public float kP, kI, kD;

	public bool PIDToggle = true;

    Rigidbody rb;

	Vector3 translational;
	PIDController3Axis translationalPid;
    Vector3 horizontal, lateral, vertical;

	Vector3 rotational;
	PIDController3Axis rotationalPid;
	Vector3 roll, pitch, yaw;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();

		translational = new Vector3();
		rotational = new Vector3();
		
		translationalPid = new PIDController3Axis(kP, kI, kD);
		rotationalPid = new PIDController3Axis(kP, kI, kD);

		thrusters = gameObject.GetComponentsInChildren<Thruster>();
	}

	// Get input from axes to control thrusters
    void Update() {
		horizontal = Input.GetAxis("Horizontal") * transform.right;
		lateral = Input.GetAxis("Lateral") * transform.up;
		vertical = Input.GetAxis("Vertical") * transform.forward;

		pitch = Input.GetAxis("Pitch") * transform.right;
		yaw = Input.GetAxis("Yaw") * transform.up;
		roll = Input.GetAxis("Roll") * transform.forward;

		translationalPid.enabled = PIDToggle;
    }
	
	// Used for rigidbody physics calculations
	void FixedUpdate () {

		translational = horizontal + lateral + vertical;
		rotational = roll + pitch + yaw;

		// Set PID targets and calculate ouput for translational axes
		translationalPid.SetTarget(translational * maxSpeed);
		var translationalOutput = translationalPid.Update(new Vector3(
			rb.velocity.x,
			rb.velocity.y,
			rb.velocity.z
		));

		// Translate the input to individual thrusters
		ThrusterController.ApplyForce(rb, translationalOutput, thrusters);

		// Set PID targets and calculate ouput for rotational axes
		rotationalPid.SetTarget(rotational * maxAngularSpeed);
		var rotationalOutput = rotationalPid.Update(new Vector3(
			rb.angularVelocity.x,
			rb.angularVelocity.y,
			rb.angularVelocity.z
		));

		// Translate the input to individual thrusters
		ThrusterController.ApplyTorque(rb, rotationalOutput, thrusters);

		// Clamp velocity magnitudes to max speeds
		rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
		rb.angularVelocity = Vector3.ClampMagnitude(rb.angularVelocity, maxAngularSpeed);
    }
}
