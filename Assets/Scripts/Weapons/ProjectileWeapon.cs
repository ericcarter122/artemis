using UnityEngine;
using System.Collections;

public class ProjectileWeapon : Weapon {


    public float fireRate;
	public int ammunition;
	public Transform barrel;
	public ParticleSystem tracer;
	public float tracerDuration;

	float nextFire = 0.0F;
	bool tracerRunning = false;

	public override void Fire() {
		if (ammunition > 0 && nextFire < Time.time) {

			if (!tracerRunning) {
				StartCoroutine (PlayTracer ());
			}

			RaycastHit hit;
			if (Physics.Raycast(barrel.position, transform.forward, out hit, range)) {

				if (hit.rigidbody != null) {
					Vector3 direction = hit.rigidbody.transform.position - transform.position;
					hit.rigidbody.AddForceAtPosition (direction.normalized * damage, hit.point);
				}

				print ("Hit object - dis: " + hit.distance);
			}

			nextFire = Time.time + fireRate;
			ammunition--;
		}
	}

	IEnumerator PlayTracer() {
		tracerRunning = true;
		tracer.Play ();
		yield return new WaitForSeconds (tracerDuration);
		tracer.Stop ();
		tracerRunning = false;
	}
}
