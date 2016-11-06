using UnityEngine;

public class Thruster : MonoBehaviour {
    public enum ThrusterType { nitrogen, hydrogen };

    public ThrusterType type;
    public float maxThrust;

    public void AddForce(Rigidbody rb, float forcePercentage) {
        Mathf.Clamp(forcePercentage, -1, 1);
        rb.AddForceAtPosition(-transform.forward * forcePercentage * maxThrust, transform.position);
    }

    // TODO: add animation/particle effects per thruster
}