using UnityEngine;
using System.Collections.Generic;

public class Targeting : MonoBehaviour {

    public List<GameObject> targets;
    public GameObject target;

    private int targetIndex;

    private float nextPress = 0.0F;
    private float pressRate = 0.1F;

	// Use this for initialization
	void Start () {
        targets = new List<GameObject>(GameObject.FindGameObjectsWithTag("Ship"));
        targetIndex = 0;
    }
	
	// Update is called once per frame
	void Update () {

        bool nextTarget = Input.GetButton("Next Target");
        List<GameObject> newTargets = new List<GameObject>(GameObject.FindGameObjectsWithTag("Ship"));

        // Check if target pool changes
        //if (!targets.Equals(newTargets)) {
        //    targets = newTargets;

        //    if (targets.Count > 0) {

        //        GameObject newTarget = null;

        //        for (int i = 0; i < targets.Count; i++) {
        //            if (target.Equals(targets[i])) {
        //                newTarget = targets[i];
        //                targetIndex = i;
        //                break;
        //            }
        //        }

        //        target = newTarget;
        //    }
        //}

        // Check if target is changed
        if (nextTarget && targets.Count > 0 && Time.time > nextPress) {

            nextPress = Time.time + pressRate;
            int nextIndex = targetIndex++;

            if (nextIndex == targets.Count) {
                nextIndex = 0;
                targetIndex = nextIndex;
            }

            target = targets[nextIndex];
        }
	}
}
