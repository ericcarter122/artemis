using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Targeting))]
public class Weapons : MonoBehaviour {

    public List<Weapon> weapons;
    public GameObject target;

	// Use this for initialization
	void Start () {
		foreach (Weapon weapon in weapons) {
			weapon.target = target;
		}
	}

	// Update is called once per frame
	void Update () {
	    if (Input.GetButton("Fire1")) {
	    	weapons[0].Fire();
        }
	}
}
