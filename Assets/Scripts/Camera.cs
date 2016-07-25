using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	public float speed;

	private float yaw = 0.0F;
    private float pitch = 0.0F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		yaw += speed * Input.GetAxis("Mouse X");
		pitch -= speed * Input.GetAxis("Mouse Y");

		transform.eulerAngles = new Vector3(pitch, yaw, 0.0F);
	}
}
