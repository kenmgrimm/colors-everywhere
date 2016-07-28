using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Zoom : MonoBehaviour {
	public GameObject paintingCamera;
	private static Slider slider;

	void Start() {
		slider = GetComponent<Slider>();
	}

	void OnGUI() {
		Vector3 pos = paintingCamera.transform.localPosition;
		paintingCamera.transform.localPosition = new Vector3(pos.x, pos.y, slider.value);
	}
}
