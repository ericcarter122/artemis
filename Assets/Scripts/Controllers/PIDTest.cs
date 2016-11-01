using UnityEngine;

[RequireComponent(typeof(PID))]
[RequireComponent(typeof(Rigidbody))]
public class PIDTest : MonoBehaviour {
	
	public float maxVelocity;

	PID pid;
	Rigidbody rb;

	void Start() {
		pid = GetComponent<PID>();
		rb = GetComponent<Rigidbody>();

		pid.timeInterval = Time.fixedDeltaTime;

		pid.kP = 0.8F;
		pid.kI = 0.1F;
		pid.kD = 0.1F;

		pid.target = 0.0F;
	}

	void FixedUpdate () {
		
		float input = Mathf.Clamp(Input.GetAxis("Horizontal"), -1, 1);

		float inputYaw = Mathf.Clamp(Input.GetAxis("Yaw"), -1, 1);

		pid.target = inputYaw * maxVelocity;

		
		rb.AddTorque(Vector3.up * pid.GetOutput(rb.angularVelocity.y));
	}
}
