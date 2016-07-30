using UnityEngine;

public abstract class Weapon : MonoBehaviour {

    public float range;
    public float damage;

    public abstract void Fire();
}
