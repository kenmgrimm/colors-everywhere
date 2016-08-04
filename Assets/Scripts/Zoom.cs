using UnityEngine;
using UnityEngine.UI;

public class Zoom : MonoBehaviour {
	public GameObject paintingCamera;
	
	private static Slider slider;
	private float lastZoomLevel;

	void Start() {
		slider = GetComponent<Slider>();
		lastZoomLevel = slider.value;
	}

	// Need to move all this to an EventTrigger
	void Update() {
		if(slider.value != lastZoomLevel) {
			float deltaZoom = slider.value - lastZoomLevel;
			paintingCamera.transform.localPosition = paintingCamera.transform.localPosition + Vector3.forward * deltaZoom; 

			lastZoomLevel = slider.value;
		}
	}
}
