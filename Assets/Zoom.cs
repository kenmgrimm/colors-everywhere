using UnityEngine;
using System.Collections;
using HedgehogTeam.EasyTouch;

public class Zoom : MonoBehaviour {
	public GameObject augmentedCamera;

	void OnEnable() {
		EasyTouch.On_PinchIn += On_PinchIn;
		EasyTouch.On_PinchOut += On_PinchOut;
		// EasyTouch.On_Swipe += On_Swipe;
	}
	void OnDisable() {
		EasyTouch.On_PinchIn -= On_PinchIn;
		EasyTouch.On_PinchOut -= On_PinchOut;
		// EasyTouch.On_Swipe -= On_Swipe;
	}
	void OnDestroy() {
		EasyTouch.On_PinchIn -= On_PinchIn;
		EasyTouch.On_PinchOut -= On_PinchOut;
		// EasyTouch.On_Swipe -= On_Swipe;
	}
	void On_PinchIn(Gesture gesture) {
		Vector3 pos = augmentedCamera.transform.localPosition;
		augmentedCamera.transform.localPosition = new Vector3(pos.x, pos.y, pos.z - 0.02f);
	}

	void On_PinchOut(Gesture gesture) {
		Vector3 pos = augmentedCamera.transform.localPosition;
		augmentedCamera.transform.localPosition = new Vector3(pos.x, pos.y, pos.z + 0.02f);
	}
}
