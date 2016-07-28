using UnityEngine;
using System.Collections;
using HedgehogTeam.EasyTouch;

public class RotatePainting : MonoBehaviour {
	public Transform parentPainting;
  private float sensitivity = 4f;

  void Start() {
		parentPainting = GameObject.Find("Painting").transform;
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

      parentPainting.Rotate(new Vector3(swipeVector.y, -swipeVector.x, 0));
		}
	}
}