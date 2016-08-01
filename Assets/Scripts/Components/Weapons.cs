using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Targeting))]
public class Weapons : MonoBehaviour {

    public List<Weapon> weapons;
	public GameObject target;

	// Use this for initialization
	void Start () {
		if (target != null) {
			foreach (Weapon weapon in weapons) {
				weapon.target = target;
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1") && target != null) {
	    	weapons[0].Fire();
			weapons[1].Fire();
			weapons[2].Fire();
			weapons[3].Fire();
        }
	}
}
