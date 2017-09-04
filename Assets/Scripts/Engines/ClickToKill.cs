using UnityEngine;
using System.Collections;

public class ClickToKill : MonoBehaviour
{
	void Update() {
		if ( Input.GetMouseButtonDown(0)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				hit.transform.GetComponent<Rigidbody> ().AddForce (-transform.forward * 50f);
			}
		}
	}
}