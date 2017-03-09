using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

	public int size = 6;

	public Color color = Color.green;

	private Texture2D crosshairTex;
	private Vector2 windowSize;
	private Rect crosshairRect;

	// Use this for initialization
	void Start () {
		crosshairTex = new Texture2D(size, size);
		windowSize = new Vector2(Screen.width, Screen.height);

		for (int y = 0; y < crosshairTex.height; y++) {
			for (int x = 0; x < crosshairTex.width; x++) {
				crosshairTex.SetPixel(x, y, color);
			}
		}
 
		crosshairTex.Apply();

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

	void OnGUI() {
		GUI.DrawTexture(crosshairRect, crosshairTex);
	}
}
