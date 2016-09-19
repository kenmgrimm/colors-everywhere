using UnityEngine;
using UnityEngine.UI;

public class Extension : MonoBehaviour {
	private Brush brush;

	private static Slider slider;
	private float lastValue;

	void Start() {
		brush = GameObject.Find("Painting Camera/Brush").GetComponent<Brush>();

		slider = GetComponent<Slider>();
		lastValue = slider.value;
	}

	// Need to move all this to an EventTrigger?
	void Update() {
		if(slider.value != lastValue) {
			brush.Extend(slider.value); 

			lastValue = slider.value;
		}
	}
}
