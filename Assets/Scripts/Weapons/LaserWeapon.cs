using UnityEngine;

public class LaserWeapon : Weapon {

    public override void Fire() {
        Physics.Raycast(transform.position, transform.forward * range);
    }
}
