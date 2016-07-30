using UnityEngine;

public class Missle : Weapon {

    public enum Targeting { heat, radar };

    public float thrust;
    public Targeting targeting;
    
    
    private Rigidbody rb;
    private bool fired = false;

    public override void Fire() {
        fired = true;
    }

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {

        if (!fired) {
            return;
        }

        rb.AddForce(transform.forward * thrust);
    }
}
