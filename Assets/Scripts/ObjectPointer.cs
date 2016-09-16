using UnityEngine;
using UnityEngine.UI;

public class ObjectPointer : MonoBehaviour {
	private static float MIN_EXTENSION = 0.01f;  // I think should be >= near clipping plane 
	private static float EXTENSION_FACTOR = 0.5f;

	private float pointerLength;

	private Color color = Color.magenta;
	private int brushType = 3;
	private float brushWidth = 2.5f;
	
	private Camera paintingCamera;

	private GameObject model;

	private Painting painting;


	void Start() {
		// Need to set starting pointerLength using extension slider.  Refactor and de-couple some of this stuff
		// DE-COUPLE
		float sliderValue = GameObject.Find("Extension Slider").GetComponent<Slider>().value;
		Extend(sliderValue);

		Debug.Log("start");
		model = GameObject.Find("a model");
		Debug.Log("start over");
		Debug.Log(model);

		paintingCamera = GameObject.Find("Painting Camera").GetComponent<Camera>();
	}

	public void Extend(float distance) {
		float newLength = distance * EXTENSION_FACTOR;
		pointerLength = newLength > MIN_EXTENSION ? newLength : MIN_EXTENSION;

		Debug.Log(Location());
	}

	private Vector3 Location() {
		// WTF is this all necessary for now?
		if(paintingCamera) {
			Ray ray = paintingCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

			return ray.origin + ray.direction * pointerLength;
		}
		return default(Vector3);
	}

	// Probably should be optimized
	void Update() {
		if(!painting) {
			painting = GameObject.FindGameObjectWithTag("Painting").GetComponent<Painting>();
		}
		if(model) {
model.transform.position = Location();
		}
		
	}

	public void StartStroke() {
		painting.StartStroke(color, brushType, brushWidth);
	}

	public void AddPoint() {
		painting.AddPoint(Location());
	}
}
