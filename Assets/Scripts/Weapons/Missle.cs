using UnityEngine;

public class Missle : Weapon {

    public enum TargetingType { heat, radar };

    [Range(0.0F, 1000.0F)]
    public float thrust;

    [Range(0.0F, 100.0F)]
    public float blastRadius;

    [Range(0.0F, 5.0F)]
    public float fuel;

    public ParticleSystem smoke;

    public TargetingType targetingType;
    
    Rigidbody rb;
    FixedJoint hardpoint;

    bool fired = false;

    public override void Fire() {
        Destroy (hardpoint);
        rb.AddForce(-transform.up * thrust);
        smoke.Play();
        fired = true;
    }

    void Start() {
        rb = GetComponent<Rigidbody>();
        hardpoint = GetComponent<FixedJoint>();
    }

    void FixedUpdate() {
        if (fired) {
            transform.LookAt(target.transform.position);
            rb.AddForce(transform.forward * thrust);
            fuel -= 0.001F;
        }

        if (fired && Vector3.Distance(transform.position, target.transform.position) <= blastRadius) {
            Destroy (this.gameObject);
        }
    }
}
