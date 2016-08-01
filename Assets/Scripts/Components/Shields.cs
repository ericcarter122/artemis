using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
public class Shields : MonoBehaviour {

    [Range(0.0F, 1.0F)]
    public float integrity;

    [Range(0, 359)]
    public float angle;

	//Collider shield;

	// Use this for initialization
	void Start () {
		//shield = GetComponent<SphereCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		
	}
}
