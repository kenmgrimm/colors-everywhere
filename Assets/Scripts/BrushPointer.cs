using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;


// Smooth curve through points
//   http://answers.unity3d.com/questions/392606/line-drawing-how-can-i-interpolate-between-points.html
public class BrushPointer : MonoBehaviour {
	private static float MIN_EXTENSION = 0.01f;  // I think should be >= near clipping plane 
	private static float EXTENSION_FACTOR = 0.5f;
  private const int TRAIL_LENGTH = 10;

	private float pointerLength;
	private Dictionary<Vector3, bool> endPoints;
	public Queue<Vector3> pointerTrailPoints;

	
	private string color = "FFFFDD00";
	private int brushType = 3;
	private float brushWidth = 2.5f;
	
	private Camera paintingCamera;

	private float transitionRate = 0.1f;
	private float transition = 0f;

	LineRenderer pointerTrail;
	public GameObject dot;

	private Painting painting;


	void Start() {
		// Need to set starting pointerLength using extension slider.  Refactor and de-couple some of this stuff
		// DE-COUPLE
		float sliderValue = GameObject.Find("Extension Slider").GetComponent<Slider>().value;
		Extend(sliderValue);

		painting = GameObject.Find("Painting").GetComponent<Painting>();
		
		paintingCamera = GameObject.Find("Painting Camera").GetComponent<Camera>();

		pointerTrail = GameObject.Find("Pointer Trail").GetComponent<LineRenderer>();

		pointerTrail.SetVertexCount(TRAIL_LENGTH);

		pointerTrailPoints = new Queue<Vector3>(TRAIL_LENGTH);

		InvokeRepeating("UpdatePointerTrail", 0, 0.05f);

		ChangeColor();
	}
	
	public void UpdatePointerTrail() {
		Vector3 point = Location();

		if(pointerTrailPoints.Count <= TRAIL_LENGTH) {
			pointerTrailPoints.Enqueue(point);
		}
		
		if(pointerTrailPoints.Count > TRAIL_LENGTH) {
			pointerTrailPoints.Dequeue();
		}

		Vector3[] trail = new Vector3[pointerTrailPoints.Count];
		Array.Copy(pointerTrailPoints.ToArray(), 0, trail, 2, trail.Length - 2);

		Vector3 pointA = Location();

		trail[0] = trail[1] = pointA;
		
		pointerTrail.SetVertexCount(trail.Length);
		pointerTrail.SetPositions(trail);
	}

	private void DrawPoint() {
		Vector3 point = Location();


	}

	public void ChangeColor() {
		color = Color.Lerp(Color.red, Color.blue, transition += transitionRate).ToString();
		if (transition > 1) { 
			transition = 0; 
		}

		Debug.Log(color);
	}

	public void Extend(float distance) {
		float newLength = distance * EXTENSION_FACTOR;
		pointerLength = newLength > MIN_EXTENSION ? newLength : MIN_EXTENSION;
	}

	private Vector3 Location() {
		Ray ray = paintingCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

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
