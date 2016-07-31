using UnityEngine;
using System.Collections;

public class LandscapeLeftOrientation : MonoBehaviour {
	void Start () {
		InvokeRepeating("UpdateOrientation", 0, 3);
	}

	private void UpdateOrientation() {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
}
