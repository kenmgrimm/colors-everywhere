using UnityEngine;
using UnityEngine.UI;

public class Brush : MonoBehaviour {
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

	public void Extend(float distance) {
		float newLength = distance * EXTENSION_FACTOR;
		pointerLength = newLength > MIN_EXTENSION ? newLength : MIN_EXTENSION;

		// Debug.Log(Location());
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

	public void ChangeColor(Color c) {}

	public void StartStroke() {
		painting.StartStroke(color, brushType, brushWidth);
	}

	public void AddPoint() {
		painting.AddPoint(Location());
	}
}


// using UnityEngine;
// using System.Collections.Generic;
// using UnityEngine.UI;


// // Smooth curve through points
// //   http://answers.unity3d.com/questions/392606/line-drawing-how-can-i-interpolate-between-points.html
// public class Brush : MonoBehaviour {
// 	private static float MIN_EXTENSION = 0.01f;  // I think should be >= near clipping plane 
// 	private static float EXTENSION_FACTOR = 0.5f;
//   private const int TRAIL_LENGTH = 10;
// 	private float FADE_FREQUENCY = 0.07f;
// 	private float DRAW_FREQUENCY = 0.05f;

// 	private float pointerLength;
// 	public Queue<Vector3> pointerTrailPoints;
// 	private Vector3 lastPoint;

// 	private Color color = Color.magenta;
// 	private int brushType = 3;
// 	private float brushWidth = 2.5f;
	
// 	private Camera paintingCamera;

// 	LineRenderer pointerTrail;

// 	private Painting painting;


// 	void Start() {
// 		// Need to set starting pointerLength using extension slider.  Refactor and de-couple some of this stuff
// 		// DE-COUPLE
// 		float sliderValue = GameObject.Find("Extension Slider").GetComponent<Slider>().value;
// 		Extend(sliderValue);

// 		painting = GameObject.FindGameObjectWithTag("Painting").GetComponent<Painting>();
		
// 		paintingCamera = GameObject.Find("Painting Camera").GetComponent<Camera>();

// 		pointerTrail = Util.LoadAndCreatePrefab("Pointer Trail", painting.transform).GetComponent<LineRenderer>();

// 		pointerTrail.SetVertexCount(0);

// 		pointerTrail.SetColors(color, color);

// 		pointerTrailPoints = new Queue<Vector3>();

// 		InvokeRepeating("UpdatePointerTrail", 0, DRAW_FREQUENCY);
// 	}
	
// 	public void UpdatePointerTrail() {
// 		Vector3 point = Location();
		
// 		if(lastPoint == null) {
// 			lastPoint = point;
// 		}

// 		if(lastPoint == null || pointerTrailPoints.Count < 5) {
// 			pointerTrailPoints.Clear();

// 			pointerTrailPoints.Enqueue(point);
// 			pointerTrailPoints.Enqueue(point + new Vector3(0.001f, 0.001f, 0.0f));
// 			pointerTrailPoints.Enqueue(point + new Vector3(-0.002f, -0.003f, -0.001f));
// 			pointerTrailPoints.Enqueue(point + new Vector3(0.001f, 0.001f, 0.002f));
// 			pointerTrailPoints.Enqueue(point + new Vector3(0.002f, -0.001f, -0.002f));

// 			lastPoint = point;
// 		}
// 		else {
// 			pointerTrailPoints.Dequeue();
// 		}

// 		// only queue if cursor moved
// 		if(lastPoint != point) {
// 			pointerTrailPoints.Enqueue(point);

// 			lastPoint = point;
// 		}

// 		pointerTrail.SetVertexCount(pointerTrailPoints.Count);
// 		pointerTrail.SetPositions(pointerTrailPoints.ToArray());
// 	}

// 	private void FadeTrail() {
// 		if(pointerTrailPoints.Count > 2) {
// 			pointerTrailPoints.Dequeue();
// 		}
// 	}

// 	public void ChangeColor(Color color) {
// 		Debug.Log("Brush.ChangeColor: " + color);

// 		this.color = color;
// 		pointerTrail.SetColors(color, color);
// 	}

// 	public void Extend(float distance) {
// 		float newLength = distance * EXTENSION_FACTOR;
// 		pointerLength = newLength > MIN_EXTENSION ? newLength : MIN_EXTENSION;
// 	}

// 	private Vector3 Location() {
// 		Ray ray = paintingCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

// 		return ray.origin + ray.direction * pointerLength;
// 	}

// 	void Update() {}

// 	public void StartStroke() {
// 		painting.StartStroke(color, brushType, brushWidth);
// 	}

// 	public void AddPoint() {
// 		painting.AddPoint(Location());
// 	}
// }
