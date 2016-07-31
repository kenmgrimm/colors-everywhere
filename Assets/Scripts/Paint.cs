using UnityEngine;
using System.Collections;
using HedgehogTeam.EasyTouch;

public class Paint : MonoBehaviour {
	public GameObject pointer;

	private float frequency = 0.1f;
	private bool shouldPaint = false;

	void Start() {

		InvokeRepeating("DrawPaint", 0, 0.25f);
	}

	void DrawPaint() {
		if(shouldPaint) {
			pointer.GetComponent<Pointer>().Paint();
			shouldPaint = false;
		}
	}

	void OnEnable() {
		EasyTouch.On_TouchDown += On_TouchDown;
	}
	void OnDisable() {
		EasyTouch.On_TouchDown -= On_TouchDown;
	}
	void OnDestroy() {
		EasyTouch.On_TouchDown -= On_TouchDown;
	}
	void On_TouchDown(Gesture gesture) {
		Debug.Log("Paint.cs Picked: " + gesture.pickedObject);
		if(gesture.pickedObject == gameObject) {
			shouldPaint = true;
		}
	}
}