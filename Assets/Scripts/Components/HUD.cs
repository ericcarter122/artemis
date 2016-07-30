using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

    public Transform progradeVector;

    private Targeting targeting;
    private Navigation nav;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        targeting = GetComponent<Targeting>();
        nav = GetComponent<Navigation>();
        rb = GetComponent<Rigidbody>();   
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate() {
        progradeVector.position = transform.position + rb.velocity.normalized * 10;
    }

    void OnGUI() {

        GUILayout.Label("ANG: " + nav.angle + " deg");

        GUILayout.Label("VEL: " + rb.velocity + " m/s");
        GUILayout.Label("ANG VEL: " + rb.angularVelocity);

        GUILayout.Label("Targets: " + targeting.targets.Count);

        GUILayout.Label("DIS: " + nav.distance);
    }
}
