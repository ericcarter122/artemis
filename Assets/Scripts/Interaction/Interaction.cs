using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour {

    public float maxDistance;
    public LayerMask interactable;
	
    private static List<GameObject> interactableObjects = new List<GameObject>();

    private Interactable selected = null;

    private static int LEFT_MOUSE_BUTTON = 0;
    private static int RIGHT_MOUSE_BUTTON = 1;
    private static int MIDDLE_MOUSE_BUTTON = 2;

    void Start() {
        // Initialize the interactable objects list
        GameObject[] gameobjects = Object.FindObjectsOfType(typeof(GameObject)) as GameObject[];

        for (int i = 0; i < gameobjects.Length; i++) {
            if (gameobjects[i].GetComponent<Interactable>() != null) {
                interactableObjects.Add(gameobjects[i]);
            }
        }
    }

	void Update () {

        // Clear all selections
        for (int i = 0; i < interactableObjects.Count; i++) {
            Renderer rend = interactableObjects[i].GetComponent<Renderer>();

            if (rend != null) {
                rend.material.SetFloat("_Outline", 0.0F);
            }
        }

        RaycastHit hit;
        Vector3 position = transform.position;
        Vector3 forward = transform.forward;
        Debug.DrawLine(position, forward * maxDistance, Color.red);

        // Check if player is highlighting an interactable object
        if (Physics.Raycast(position, forward, out hit, maxDistance, interactable)) {
            GameObject go = hit.transform.gameObject;
            Renderer rend = go.GetComponent<Renderer>();

            selected = go.GetComponent<Interactable>();

            if (rend != null) {
                rend.material.SetFloat("_Outline", 0.03F);
            }

            // Check if object is clicked and call the interactable's OnClick
            if (selected != null && Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON)) {
                selected.OnClick();
            }
        }
    }
}
