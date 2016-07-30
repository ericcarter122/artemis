using UnityEngine;
using System.Collections;

public class Shields : MonoBehaviour {

	[Range(0.0F, 100.0F)]
    public float radius;

    [Range(0.0F, 1.0F)]
    public float integrity;

    [Range(0, 359)]
    public float angle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
