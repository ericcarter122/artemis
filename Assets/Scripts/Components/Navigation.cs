using UnityEngine;
using System.Collections;

public class Navigation : MonoBehaviour {

	public Transform reference { get; set; }
    public Vector3 angle { get; set; }
    public float distance { get; set; }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (reference != null) {

			distance = Vector3.Distance (reference.position, transform.position);

			Vector3 newAngle = new Vector3 ();

			newAngle.x = Vector3.Angle (transform.right, reference.right);
			newAngle.y = Vector3.Angle (transform.forward, reference.forward);
			newAngle.z = Vector3.Angle (transform.up, reference.up);

			angle = newAngle;

		} else {
			angle = new Vector3 ();
			distance = 0;
		}
    }
}
