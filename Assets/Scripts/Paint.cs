using UnityEngine;
using System.Collections;
using HedgehogTeam.EasyTouch;

public class Paint : MonoBehaviour {
	public GameObject pointer;

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
			pointer.GetComponent<Pointer>().Paint();
		}
	}
}