using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class SpaceDust : MonoBehaviour {

	public int maxParticles;
	public float particleSize;
	public float radius;

	ParticleSystem spaceDust;
	ParticleSystem.Particle[] points;

	// Use this for initialization
	void Start () {
		spaceDust = GetComponent<ParticleSystem> ();
	}

	void CreateDust() {
		points = new ParticleSystem.Particle[maxParticles];

		for (int i = 0; i < maxParticles; i++) {
			points [i].position = Random.insideUnitSphere * radius + transform.position;
			points [i].startColor = Color.white;
			points [i].startSize = particleSize;
		
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (points == null) {
			CreateDust ();
		}

		for (int i = 0; i < maxParticles; i++) {

			if (Vector3.Distance (points [i].position, transform.position) > radius) {
				points [i].position = Random.insideUnitSphere * radius + transform.position;
			}

		}

		spaceDust.SetParticles (points, points.Length);
	}
}
