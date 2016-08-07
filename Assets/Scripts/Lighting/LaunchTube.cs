using UnityEngine;
using System.Collections;

public class LaunchTube : MonoBehaviour {

	public float railSpeed;
	public float thrust;
	public Transform launchPad;

	Rigidbody rb;
	Coroutine lightPattern;

	// Use this for initialization
	void Start () {

		rb = Camera.main.GetComponent<Rigidbody> ();

		UnLightTube ();
		lightPattern = StartCoroutine(LightPattern (0.1F, 0.25F));

		StartCoroutine (PrepareLaunch());
	}

	IEnumerator LightPattern(float delay, float interval) {

		int lightIndex = 0;

		while (true) {
			
			lightIndex = 0;
			while (lightIndex < transform.childCount) {
				
				Transform leftLight = transform.GetChild (lightIndex);
				Transform rightLight = transform.GetChild (lightIndex + 1);

				leftLight.GetComponent<Light> ().enabled = true;
				rightLight.GetComponent<Light> ().enabled = true;

				lightIndex += 2;
				yield return new WaitForSeconds (delay);
			}

			lightIndex = transform.childCount;
			while (lightIndex > 0) {

				Transform leftLight = transform.GetChild (lightIndex - 1);
				Transform rightLight = transform.GetChild (lightIndex - 2);

				leftLight.GetComponent<Light> ().enabled = false;
				rightLight.GetComponent<Light> ().enabled = false;

				lightIndex -= 2;
				yield return new WaitForSeconds (delay);
			}
			yield return new WaitForSeconds (interval);
		}
	}

	IEnumerator PrepareLaunch() {

		yield return new WaitForSeconds (2F);

		while (Vector3.Distance (rb.position, launchPad.position) > 0.1F) {
			rb.velocity = transform.forward * railSpeed;
			yield return null;
		}

		UnLightTube ();
		StopCoroutine (lightPattern);
		LightTube ();

		rb.velocity = Vector3.zero;
		yield return new WaitForSeconds(1.5F);

		UnLightTube ();
		yield return new WaitForSeconds(0.2F);
		LightTube ();
		yield return new WaitForSeconds (0.2F);
		UnLightTube ();
		yield return new WaitForSeconds (0.2F);
		LightTube ();
		
		StartCoroutine (Launch(0.0F));
		yield return null;
	}

	IEnumerator Launch (float delay) {
		yield return new WaitForSeconds (delay);

		while (true) {
			rb.AddForce (transform.forward * thrust);
			yield return null;
		}
	}

	void UnLightTube() {
		foreach (Transform child in transform) {
			child.GetComponent<Light> ().enabled = false;
		}
	}

	void LightTube() {
		foreach (Transform child in transform) {
			child.GetComponent<Light> ().enabled = true;
		}
	}
}
