using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Targeting))]
[RequireComponent(typeof(Navigation))]
public class HUD : MonoBehaviour {

    public Transform progradeVector;

    private Targeting targeting;
    private Navigation nav;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        targeting = GetComponent<Targeting>();
        nav = GetComponent<Navigation>();
		rb = GetComponent<Rigidbody> ();
	}

    void FixedUpdate() {
        progradeVector.position = transform.position + rb.velocity.normalized;
    }

    void OnGUI() {

        GUILayout.Label("ANG: " + nav.angle + " deg");

		GUILayout.Label("VEL: " + (rb.velocity * (10F)) + " m/s");
        GUILayout.Label("ANG VEL: " + rb.angularVelocity);

		GUILayout.Label("Targets: " + targeting.targets.Length);

        GUILayout.Label("DIS: " + nav.distance);
    }
}
