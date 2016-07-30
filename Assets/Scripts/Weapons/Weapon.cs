using UnityEngine;

public abstract class Weapon : MonoBehaviour {

    public float range;
    public float damage;
    public GameObject target { get; set; }

    public abstract void Fire();
}
