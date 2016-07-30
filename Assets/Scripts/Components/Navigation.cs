using UnityEngine;
using System.Collections;

public class Navigation : MonoBehaviour {

    public Transform station;
    public Vector3 angle { get; set; }
    public float distance { get; set; }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		distance = Vector3.Distance(station.position, transform.position);

        angle = new Vector3(
        	Vector3.Angle(transform.right, station.right),
        	Vector3.Angle(transform.forward, station.forward),
        	Vector3.Angle(transform.up, station.up));
    }
}
