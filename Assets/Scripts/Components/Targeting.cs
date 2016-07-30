using UnityEngine;
using System.Collections.Generic;

public class Targeting : MonoBehaviour {

    public GameObject target;

    [Range(0.0F, 1000.0F)]
    public float radarRadius;

    [Range(30.0F, 300.0F)]
    public float radarFrequency;

    public List<GameObject> targets { get; set; }

    //private int targetIndex = 0;

    //private float nextPress = 0.0F;
    //private float pressRate = 0.1F;

	// Use this for initialization
	void Start () {
        targets = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {

        //bool nextTarget = Input.GetButton("Next Target");

        //// Check if target is changed
        //if (nextTarget && targets.Count > 0 && Time.time > nextPress) {

        //    nextPress = Time.time + pressRate;
        //    int nextIndex = targetIndex++;

        //    if (nextIndex == targets.Count) {
        //        nextIndex = 0;
        //        targetIndex = nextIndex;
        //    }

        //    target = targets[nextIndex];
        //}
	}

    void FixedUpdate() {
        targets.Clear();

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radarRadius);
        for (int i = 0; i < hitColliders.Length; i++) {
            targets.Add(hitColliders[i].gameObject);
        }
    }
}
