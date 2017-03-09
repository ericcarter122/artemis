using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSwitch : MonoBehaviour, Interactable {

	public GameObject switchHandle;
	public GameObject rotateAround;
	public float deltaAngle = 30;
	private bool toggled = false;

	public void OnClick() {
		Transform t = switchHandle.transform;
		if (!toggled) {
			t.RotateAround(rotateAround.transform.position, t.right, deltaAngle);
		} else {
			t.RotateAround(rotateAround.transform.position, t.right, -deltaAngle);
		}
		toggled = !toggled;
	}
}
