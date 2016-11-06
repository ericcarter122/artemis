using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Engines : MonoBehaviour {

	// TODO: implement multiple modeled thrusters (main, cold gas)
	public Thruster[] thrusters;

	public float maxSpeed, maxAngularSpeed;

	[Range(0, Mathf.Infinity)]
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

		rotationalPid = new PidController3Axis(kP, kI, kD);
	}

	// Get input from axes to control thrusters
    void Update() {
		horizontal = Input.GetAxis("Horizontal");
        lateral = Input.GetAxis("Lateral");
        vertical = Input.GetAxis("Vertical");
        pitch = Input.GetAxis("Pitch");
        yaw = Input.GetAxis("Yaw");
        roll = Input.GetAxis("Roll");

		translationalPid.enabled = flightAssistToggle;
    }
	
	// Used for rigidbody physics calculations
	void FixedUpdate () {

		translational = new Vector3(horizontal, lateral, vertical);
		rotational = new Vector3(pitch, yaw, roll);

		Debug.DrawLine(transform.position, transform.position + translational, Color.red);

		localVelocity = transform.InverseTransformDirection(rb.velocity);

		// Set PID targets and calculate ouput for translational axes
		translationalPid.SetTarget(translational * maxSpeed);
		var translationalOutput = translationalPid.Update(new Vector3(
			localVelocity.x,
			localVelocity.y,
			localVelocity.z
		));

		ThrusterController.ApplyForce(rb, translationalOutput, thrusters);

		// // Calculate local angular/translational velocity, as velocity is in world space
		// localAngularVelocity = transform.InverseTransformDirection(rb.angularVelocity);

		// // Set PID targets and calculate ouput for rotational axes
		// rotationalPid.SetTarget(rotational * maxAngularSpeed);
		// var rotationalOutput = rotationalPid.Update(new Vector3(
		// 	localAngularVelocity.x,
		// 	localAngularVelocity.y,
		// 	localAngularVelocity.z
		// ));

		// rb.AddRelativeTorque(Vector3.right * rotationalOutput.x);
		// rb.AddRelativeTorque(Vector3.up * rotationalOutput.y);
		// rb.AddRelativeTorque(Vector3.forward * rotationalOutput.z);

		rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
		rb.angularVelocity = Vector3.ClampMagnitude(rb.angularVelocity, maxAngularSpeed);
    }
}
