using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Engines : MonoBehaviour {

	// TODO: implement multiple modeled thrusters (main, cold gas)
	public Thruster[] thrusters;

	public float maxSpeed, maxAngularSpeed;
	public float maxThrust, maxAngularThrust;

	[Range(0, 10.0F)]
	public float kP, kI, kD;

	public bool flightAssistToggle = true;

    Rigidbody rb;

	Vector3 translational;
	PidController3Axis translationalPid;
    float horizontal, lateral, vertical;

	Vector3 rotational;
	PidController3Axis rotationalPid;
    float roll, pitch, yaw;

	Vector3 localAngularVelocity;
	Vector3 localVelocity;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		localAngularVelocity = new Vector3();
		localVelocity = new Vector3();

		translational = new Vector3();
		rotational = new Vector3();
		
		translationalPid = new PidController3Axis(kP, kI, kD);
		translationalPid.outputMax = maxThrust;

		rotationalPid = new PidController3Axis(kP, kI, kD);
		rotationalPid.outputMax = maxAngularThrust;
	}

	// Get input from axes to control thrusters
    void Update() {
		horizontal = Input.GetAxis("Horizontal");
        lateral = Input.GetAxis("Lateral");
        vertical = Input.GetAxis("Vertical");
        pitch = Input.GetAxis("Pitch");
        yaw = Input.GetAxis("Yaw");
        roll = Input.GetAxis("Roll");

		translationalPid.SetGains(kP, kI, kD);
		rotationalPid.SetGains(kP, kI, kD);

		translationalPid.enabled = flightAssistToggle;
    }
	
	// Used for rigidbody physics calculations
	void FixedUpdate () {

		translational = new Vector3(horizontal, lateral, vertical);
		rotational = new Vector3(pitch, yaw, roll);

		// Calculate local angular/translational velocity, as velocity is in world space
		localAngularVelocity = transform.InverseTransformDirection(rb.angularVelocity);
		localVelocity = transform.InverseTransformDirection(rb.velocity);

		// Set PID targets and calculate ouput for rotational axes
		rotationalPid.SetTarget(rotational * maxAngularSpeed);
		var rotationalOutput = rotationalPid.Update(new Vector3(
			localAngularVelocity.x,
			localAngularVelocity.y,
			localAngularVelocity.z
		));

		rb.AddRelativeTorque(Vector3.right * rotationalOutput.x);
		rb.AddRelativeTorque(Vector3.up * rotationalOutput.y);
		rb.AddRelativeTorque(Vector3.forward * rotationalOutput.z);

		rb.angularVelocity = Vector3.ClampMagnitude(rb.angularVelocity, maxAngularSpeed);

		// Set PID targets and calculate ouput for translational axes
		translationalPid.SetTarget(translational * maxSpeed);
		var translationalOutput = translationalPid.Update(new Vector3(
			localVelocity.x,
			localVelocity.y,
			localVelocity.z
		));

		rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

		rb.AddRelativeForce(Vector3.right * translationalOutput.x);
		rb.AddRelativeForce(Vector3.up * translationalOutput.y);
		rb.AddRelativeForce(Vector3.forward * translationalOutput.z);
    }
}
