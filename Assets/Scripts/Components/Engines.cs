using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Engines : MonoBehaviour {

    public float thrust;
    public float angularThrust;
	public float maxSpeed;

	public bool rcsStabalization = true;
	public bool inertialDampener = true;

    Rigidbody rb;

    float horizontal;
    float lateral;
    float vertical;

    float roll;
    float pitch;
    float yaw;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}

    void Update() {
        horizontal = Input.GetAxis("Horizontal");
        lateral = Input.GetAxis("Lateral");
        vertical = Input.GetAxis("Vertical");

        pitch = Input.GetAxis("Pitch");
        yaw = Input.GetAxis("Yaw");
        roll = Input.GetAxis("Roll");
    }
	
	// Used for rigidbody physics calculations
	void FixedUpdate () {

		Vector3 force = new Vector3 ();
		Vector3 torque = new Vector3 ();

		// Get initial input
		force.x = horizontal * thrust;
		force.y = lateral * thrust;
		force.z = vertical * thrust;

		torque.x = pitch * angularThrust;
		torque.y = yaw * angularThrust;
		torque.z = roll * angularThrust;
	
		Vector3 relativeVelocity = transform.InverseTransformDirection (rb.velocity);

		// RCSTAB
		if (rcsStabalization) {
			
			float angle = Vector3.Angle (transform.forward, relativeVelocity);

			if (!force.Equals (Vector3.zero) && angle > 0) {
				if (force.x == 0)
					force.x = -Mathf.Sign (relativeVelocity.x) * thrust;
				if (force.y == 0)
					force.y = -Mathf.Sign (relativeVelocity.y) * thrust;
				if (force.z == 0)
					force.z = -Mathf.Sign (relativeVelocity.z) * thrust;
			}

		}

		// Inertial Dampeners
		if (inertialDampener) {
			if (force.x == 0)
				force.x = -Mathf.Sign (relativeVelocity.x) * thrust;
			if (force.y == 0)
				force.y = -Mathf.Sign (relativeVelocity.y) * thrust;
			if (force.z == 0)
				force.z = -Mathf.Sign (relativeVelocity.z) * thrust;
		}

		// Finalize vectors
		rb.AddForce (transform.right * force.x);
		rb.AddForce (transform.up * force.y);
		rb.AddForce (transform.forward * force.z);

		rb.AddTorque (transform.right * pitch * angularThrust);
		rb.AddTorque (transform.up * yaw * angularThrust);
		rb.AddTorque (transform.forward * roll * angularThrust);

		Debug.DrawLine (transform.position, force + transform.position, Color.red);
		Debug.DrawLine (transform.position, transform.forward + transform.position, Color.green);
		Debug.DrawLine (transform.position, rb.velocity + transform.position, Color.yellow);

		if (rb.velocity.magnitude > maxSpeed) {
			rb.velocity = rb.velocity.normalized * maxSpeed;
		}
    }
}
