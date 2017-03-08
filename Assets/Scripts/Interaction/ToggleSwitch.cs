using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSwitch : MonoBehaviour, Interactable {

	public float deltaAngle = 60;
	private Vector3 axis;
	private bool toggled = false;

	public void Start() {
		axis = transform.right;
	}

	public void OnClick() {
		float angle = 0;
		transform.rotation.ToAngleAxis(out angle, out axis);
		if (!toggled) {
			transform.rotation = Quaternion.AngleAxis(angle + deltaAngle, axis);
		} else {
			transform.rotation = Quaternion.AngleAxis(angle - deltaAngle, axis);;
		}
		toggled = !toggled;
	}
}
