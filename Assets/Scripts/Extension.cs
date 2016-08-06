using UnityEngine;
using UnityEngine.UI;

public class Extension : MonoBehaviour {
	private Pointer pointer;

	private static Slider slider;
	private float extensionLength;

	void Start() {
		pointer = GameObject.Find("Painting Camera/Pointer").GetComponent<Pointer>();

		slider = GetComponent<Slider>();
		extensionLength = slider.value;
	}

	// Need to move all this to an EventTrigger?
	void Update() {
		if(slider.value != extensionLength) {
			float deltaLength = slider.value - extensionLength;
			pointer.Extend(deltaLength); 

			extensionLength = slider.value;
		}
	}
}
