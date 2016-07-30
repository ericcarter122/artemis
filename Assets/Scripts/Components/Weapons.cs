using UnityEngine;
using System.Collections.Generic;

public class Weapons : MonoBehaviour {

    public List<Weapon> weapons;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButton("Fire1")) {
            weapons[0].Fire();
        }
	}
}
