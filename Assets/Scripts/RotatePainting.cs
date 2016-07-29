using UnityEngine;
using System.Collections;
using HedgehogTeam.EasyTouch;

public class RotatePainting : MonoBehaviour {
  private float sensitivity = 4f;
	// GameObject paintingCamera;

  void Start() { 
		// paintingCamera = GameObject.Find("Painting Camera");
	}

	void OnEnable() {
		EasyTouch.On_Swipe += On_Swipe;
	}
	void OnDisable() {
		EasyTouch.On_Swipe -= On_Swipe;
	}
	void OnDestroy() {
		EasyTouch.On_Swipe -= On_Swipe;
	}

	void On_Swipe(Gesture gesture) {
		Debug.Log("RotatePainting.cs Picked: " + gesture.pickedObject);
		if(gesture.pickedObject == null) {
      Vector2 swipeVector = gesture.swipeVector / sensitivity;

      transform.Rotate(new Vector3(swipeVector.y, -swipeVector.x, 0));
			// Should be rotating around orientation of the Physical Camera, pivot of painting
			// transform.RotateAround(transform.position, paintingCamera.transform.rotation, 0);
		}
	}
}