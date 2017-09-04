using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(RawImage))]
public class Waypoint : MonoBehaviour {

	public Texture texture;

	public float width = 8;
	public float height = 6;

	// Use this for initialization
	void Start () {
		Canvas canvas = GetComponent<Canvas>();
		RawImage image = GetComponent<RawImage>();
		canvas.renderMode = RenderMode.WorldSpace;
		RectTransform rectTransform = canvas.GetComponent<RectTransform>();
		rectTransform.sizeDelta = new Vector2(width, height);
		image.texture = texture;
		image.raycastTarget = false;
	}
}
