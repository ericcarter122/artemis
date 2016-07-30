using UnityEngine;
using System.Collections;

public class Engines : MonoBehaviour {

    [Range(0.0F, 10000.0F)]
    public float thrust;

    [Range(0.0F, 10000.0F)]
    public float angularThrust;

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

        rb.AddForce(transform.right * horizontal * thrust);
        rb.AddForce(transform.up * lateral * thrust);
        rb.AddForce(transform.forward * vertical * thrust);

        rb.AddTorque(transform.right * pitch * angularThrust);
        rb.AddTorque(transform.up * yaw * angularThrust);
        rb.AddTorque(transform.forward * roll * angularThrust);

    }
}
