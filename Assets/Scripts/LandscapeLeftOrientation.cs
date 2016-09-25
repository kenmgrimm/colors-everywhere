using UnityEngine;

public class LandscapeLeftOrientation : MonoBehaviour {
	void Start () {
		// Screen.orientation = ScreenOrientation.LandscapeLeft;
		InvokeRepeating("UpdateOrientation", 0, 3);
	}

	private void UpdateOrientation() {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
}
