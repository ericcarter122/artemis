using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

	private Texture2D crosshairTex;
	private Vector2 windowSize;
	private Rect crosshairRect;

	// Use this for initialization
	void Start () {
		crosshairTex = new Texture2D(2, 2);
		windowSize = new Vector2(Screen.width, Screen.height);
		CalculateRect();
	}
	
	// Update is called once per frame
	void Update () {
		if (windowSize.x != Screen.width || windowSize.y != Screen.height) {
			CalculateRect();
		}
	}

	void CalculateRect() {
		crosshairRect = new Rect(
			(windowSize.x - crosshairTex.width) / 2.0F,
			(windowSize.y - crosshairTex.height) / 2.0F,
			crosshairTex.width, crosshairTex.height);
	}

	void OnGui() {
		GUI.DrawTexture(crosshairRect, crosshairTex);
	}
}
