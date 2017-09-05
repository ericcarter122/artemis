using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallastTank : MonoBehaviour {

	public Rigidbody parentRigidbody;

	// Density of the water (default is distilled water in kg/m^3)
	public float waterDensity = 1000F;

	// Rate water can be pumped in an out of the tank in m^3/s
	public float pumpRate = 1.5F;

	// Volume of the tank (default is dimensions of actual ballast tanks in m^3)
	// TODO: Add volume of the rest of the sub here
	public float volume = 0.00927F;

	// Volume of water currently in the tank
	float waterVolume;

	// Force to apply buoyancy up
	float buoyancyMagnitude;

	void Start() {
		// Start the tank full
		waterVolume = volume;
		// TODO: Get the volume of 	the submarine using the mesh data
	}

	void FixedUpdate () {

		// TODO: Calculate the buoyancy force of the tank
		// Net volume of displaced liquid = (volume of the submarine) + (volume of the ballast tank) - (volume of water in the ballast tank) (m^3)
		float netVolume = volume - waterVolume + 0.0004F;
		// Buoyancy force = (density of liquid) * (volume of liquid displaced) * (gravity)
		buoyancyMagnitude = waterDensity * netVolume * Physics.gravity.magnitude;

		Vector3 force = buoyancyMagnitude * Vector3.up;

		parentRigidbody.AddForceAtPosition (force, transform.position);
		Debug.DrawLine (transform.position, transform.position + force.normalized, Color.yellow);
	}
}
