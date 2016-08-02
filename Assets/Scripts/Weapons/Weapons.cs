using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Weapons : MonoBehaviour {

	public List<Weapon> weapons;

	void Update() {
		if (Input.GetButton ("Fire1")) {
			if (weapons != null) {
				foreach (Weapon weapon in weapons) {
					weapon.Fire ();
				}
			}
		}
	}
}
