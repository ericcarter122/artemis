using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileWeapon : Weapon {

    public float fireRate;
	public float speed;
	public int ammunition;
	public GameObject projectile;

	Rigidbody rb;
	float nextFire = 0.0F;

	void Start() {
		rb = GetComponent<Rigidbody> ();
	}

	public override void Fire() {
		if (ammunition > 0 && nextFire < Time.time) {
			GameObject clone = Instantiate (projectile, transform.position, transform.rotation) as GameObject;

			Projectile cloneProjectile = clone.GetComponent<Projectile> ();
			cloneProjectile.range = range;
			cloneProjectile.damage = damage;
			cloneProjectile.speed = speed;
			cloneProjectile.GetComponent<Rigidbody>().velocity += rb.velocity;

			nextFire = Time.time + (60 / fireRate);
			ammunition--;
		}
	}
}
