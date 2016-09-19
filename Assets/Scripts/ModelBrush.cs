using UnityEngine;
using UnityEngine.UI;

public class ModelBrush : Brush {
	private static float MIN_EXTENSION = 0.01f;  // I think should be >= near clipping plane 
	private static float EXTENSION_FACTOR = 0.5f;

	private float pointerLength;

	private Color color = Color.magenta;
	private int brushType = 3;
	private float brushWidth = 2.5f;
	
	private Camera paintingCamera;

	private GameObject model;

	private Painting painting;


	void Awake() {
		paintingCamera = GameObject.Find("Painting Camera").GetComponent<Camera>();
		model = GameObject.Find("a model");
		
		// Need to set starting pointerLength using extension slider.  Refactor and de-couple some of this stuff
		// DE-COUPLE
		float sliderValue = GameObject.Find("Extension Slider").GetComponent<Slider>().value;
		
		Extend(sliderValue);
	}

	public override void Extend(float distance) {
		float newLength = distance * EXTENSION_FACTOR;
		pointerLength = newLength > MIN_EXTENSION ? newLength : MIN_EXTENSION;
	}

	private Vector3 Location() {
		Ray ray = paintingCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

		return ray.origin + ray.direction * pointerLength;
	}

	private Vector3 LocationOnGround() {
		Vector3 groundLocation = Location();
		groundLocation.y = 0;

		return groundLocation;
	}

	// Probably should be optimized
	void Update() {
		// Necesary because painting is now instantiated...  Gotta fix this...
		if(!painting) {
			painting = GameObject.FindGameObjectWithTag("Painting").GetComponent<Painting>();
		}
		
		model.transform.position = LocationOnGround();
	}

	public override void ChangeColor(Color c) {}

	public void StartStroke() {
		painting.StartStroke(color, brushType, brushWidth);
	}

	public void AddPoint() {
		painting.AddPoint(Location());
	}
}
