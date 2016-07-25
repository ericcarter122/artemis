using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

    private Targeting targeting;
    private Engines engines;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        targeting = GetComponent<Targeting>();
        engines = GetComponent<Engines>();
        rb = GetComponent<Rigidbody>();   
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI() {

        GUILayout.Label("VEL: " + rb.velocity.z + " m/s");

        // Move to navigation script
        float heading = Vector3.Angle(transform.forward, engines.station.forward);
        GUILayout.Label("HDG: " + heading + " deg");

        GUILayout.Label("FLT ASST: " + engines.flightAssist);

        GUILayout.Label("Target: " + targeting.target.name);

        GameObject target = targeting.target;
        GUILayout.Label("Distance: " + Vector3.Distance(transform.position, target.transform.position) + " m");
    }
}
