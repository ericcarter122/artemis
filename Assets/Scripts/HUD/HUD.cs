using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	// HUD color
	public Color color;

	// Components from spacecraft
	public Engines engines;
	public Shields shields;
	public Navigation navigation;
	public Radar radar;
	public Infrared infrared;
	public Weapons weapons;
	public Jammer jammer;
	public MagneticLock magneticLock;

	void OnGUI() {
		if (engines != null) DrawEngines ();
	}

	void DrawEngines() {

	}
}
