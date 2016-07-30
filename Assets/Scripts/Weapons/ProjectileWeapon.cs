using UnityEngine;
using System.Collections;

public class ProjectileWeapon : Weapon {

    public float fireRate;
    public GameObject projectile;

	public override void Fire() {
        Instantiate(projectile, transform.position, transform.rotation);
    }
}
