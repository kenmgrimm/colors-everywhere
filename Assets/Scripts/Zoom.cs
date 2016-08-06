using UnityEngine;
using UnityEngine.UI;

public class Zoom : MonoBehaviour {
	// This should probably match or be close to the Extension factor
	private static float ZOOM_FACTOR = 0.5f;
	public GameObject paintingCamera;
	
	private static Slider slider;
	private Vector3 basePosition;
	private float lastZoom;

	void Start() {
		basePosition = paintingCamera.transform.localPosition;
		slider = GetComponent<Slider>();
		lastZoom = slider.value;
	}

	private void ZoomTo(float zoom) {
		paintingCamera.transform.localPosition = basePosition + Vector3.forward * ZOOM_FACTOR * zoom;
	}

	// Need to move all this to an EventTrigger?
	void Update() {
		if(slider.value != lastZoom) {
			ZoomTo(slider.value);

			lastZoom = slider.value;
		}
	}
}
