using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Thruster : MonoBehaviour{
    public enum ThusterType { nitrogen, hydrogen };

    public float maxThrust;

    Rigidbody rb;

    public void Start() {
        rb = GetComponent<Rigidbody>();
    }

    public void AddForce(Vector3 force) {
        rb.AddForceAtPosition(force, transform.position);
    }

    // TODO: add animation/particle effects per thruster
}