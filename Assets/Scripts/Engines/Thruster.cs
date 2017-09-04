using UnityEngine;

public class Thruster : MonoBehaviour {
    
	public float maxThrust;

    public void AddForce(Rigidbody rb, float forcePercentage) {
		forcePercentage = Mathf.Clamp (forcePercentage, -1, 1);
        rb.AddForceAtPosition(-transform.forward * forcePercentage * maxThrust, transform.position);
		Debug.DrawLine(transform.position, transform.position + transform.forward * forcePercentage, Color.red);
    }
}