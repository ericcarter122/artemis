using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

    public Texture texture;

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

    void OnGUI() {

        GUILayout.Label("ANG: " + nav.angle + " deg");

        GUILayout.Label("VEL: " + rb.velocity + " m/s");
        GUILayout.Label("ANG VEL: " + rb.angularVelocity);

        GUILayout.Label("Targets: " + targeting.targets.Count);

        GUILayout.Label("DIS: " + nav.distance);

        GUI.DrawTexture(new Rect(200, 200, 60, 60), texture);
        
    }
}
