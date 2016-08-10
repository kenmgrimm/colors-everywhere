using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


// Smooth curve through points
//   http://answers.unity3d.com/questions/392606/line-drawing-how-can-i-interpolate-between-points.html
public class BrushPointer : MonoBehaviour {
	private static float MIN_EXTENSION = 0.01f;  // I think should be >= near clipping plane 
	private static float EXTENSION_FACTOR = 0.5f;

	private float pointerLength;
	private Dictionary<Vector3, bool> endPoints;
	
	private string color = "FFFFDD00";
	private int brushType = 3;
	private float brushWidth = 2.5f;
	
	private Camera augmentedCamera;

	private float transitionRate = 0.1f;
	private float transition = 0f;

	public GameObject dot;

	private Painting painting;


	void Start() {
		// Need to set starting pointerLength using extension slider.  Refactor and de-couple some of this stuff
		// DE-COUPLE
		float sliderValue = GameObject.Find("Extension Slider").GetComponent<Slider>().value;
		Extend(sliderValue);

		painting = GameObject.Find("Painting").GetComponent<Painting>();
		
		augmentedCamera = GameObject.Find("Painting Camera").GetComponent<Camera>();

		ChangeColor();
	}

	public void ChangeColor() {
		color = Color.Lerp(Color.red, Color.blue, transition += transitionRate).ToString();
		if (transition > 1) { transition = 0; }

		Debug.Log(color);
	}

	public void Extend(float distance) {
		float newLength = distance * EXTENSION_FACTOR;
		pointerLength = newLength > MIN_EXTENSION ? newLength : MIN_EXTENSION;
	}

	private Vector3 Location() {
		Ray ray = augmentedCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

		return ray.origin + ray.direction * pointerLength;
	}

	void Update() {}

	public void StartStroke() {
		painting.StartStroke(color, brushType, brushWidth);
	}

	public void AddPoint() {
		painting.AddPoint(Location());
	}
}
