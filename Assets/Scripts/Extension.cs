using UnityEngine;
using UnityEngine.UI;

public class Extension : MonoBehaviour {
	private Pointer pointer;

	private static Slider slider;
	private float lastValue;

	void Start() {
		pointer = GameObject.Find("Painting Camera/Pointer").GetComponent<Pointer>();

		slider = GetComponent<Slider>();
		lastValue = slider.value;
	}

	// Need to move all this to an EventTrigger?
	void Update() {
		if(slider.value != lastValue) {
			pointer.Extend(slider.value); 

			lastValue = slider.value;
		}
	}
}
