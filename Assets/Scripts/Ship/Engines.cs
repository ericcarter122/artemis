﻿using UnityEngine;
using System.Collections;

public class Engines : MonoBehaviour {

	public float thrust;
	public float rotationalThrust;
	public Transform station;

	private Rigidbody rb;
	private bool m_flightAssist;

	private float toggleRate;
	private float nextToggle;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		m_flightAssist = true;
		toggleRate = 0.5F;
		nextToggle = 0.0F;
	}
	
	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxis("Horizontal");
		float lateral = Input.GetAxis("Lateral");
		float vertical = Input.GetAxis("Vertical");

		float pitch = Input.GetAxis("Pitch");
		float yaw = Input.GetAxis("Yaw");
		float roll = Input.GetAxis("Roll");

		Vector3 translational = new Vector3(horizontal, lateral, vertical);

		rb.AddForce(transform.right * horizontal * thrust);
		rb.AddForce(transform.up * lateral * thrust);
		rb.AddForce(transform.forward * vertical * thrust);

		rb.AddTorque(transform.right * pitch * rotationalThrust);
		rb.AddTorque(transform.up * yaw * rotationalThrust);
		rb.AddTorque(transform.forward * roll * rotationalThrust);

		float brake = Input.GetAxis("Brake");
		bool flightAssistToggle = Input.GetButton("Flight Assist Toggle");

		Vector3 norm = -Vector3.Normalize(rb.velocity);

		if (flightAssistToggle && Time.time > nextToggle) {
			m_flightAssist = !m_flightAssist;
			nextToggle = Time.time + toggleRate;
		}

		// Dampen all extraneous forces
		if (flightAssist) {
			if (translational == Vector3.zero)
				rb.AddForce(norm * thrust);
		}
		else
			rb.AddForce(norm * brake * thrust);
	}

    public bool flightAssist {
        get { return m_flightAssist; }
    }
}
