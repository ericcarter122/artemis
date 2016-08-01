using UnityEngine;

public abstract class Weapon : MonoBehaviour {

    public float range;
    public float damage;

    [HideInInspector]
    public GameObject target;

    public abstract void Fire();
}
