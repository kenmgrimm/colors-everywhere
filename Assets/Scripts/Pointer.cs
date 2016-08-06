using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;


// Smooth curve through points
//   http://answers.unity3d.com/questions/392606/line-drawing-how-can-i-interpolate-between-points.html
public class Pointer : MonoBehaviour {
	private static float MIN_EXTENSION = 0.01f;  // I think should be >= near clipping plane 
	private static float EXTENSION_FACTOR = 0.5f;
	private static int MIN_TRAIL_LENGTH = 20;
	private static int MAX_TRAIL_LENGTH = 45;

	private float pointerLength;
	private Dictionary<Vector3, bool> endPoints;
	private Camera augmentedCamera;

	private Transform parentPainting;

	private Renderer rend;
	private Color lerpedColor;
	private float transitionRate = 0.1f;
	private float transition = 0f;

	public GameObject dot;

	private LineRenderer lineWave;
	private List<Vector3> wavePoints;

	private Dictionary<Vector3, bool> pointerTrailDict;
	private Queue<Vector3> pointerTrailPoints;
	private LineRenderer pointerTrailRend;

	void Start() {
		// Need to set starting pointerLength using extension slider.  Refactor and de-couple some of this stuff
		// DE-COUPLE
		float sliderValue = GameObject.Find("Extension Slider").GetComponent<Slider>().value;
		Extend(sliderValue);
		
		lineWave = GameObject.Find("Line Wave Auto").GetComponent<LineRenderer>();
		wavePoints = new List<Vector3>();
		endPoints = new Dictionary<Vector3, bool>();

		pointerTrailRend = GameObject.Find("Pointer Trail").GetComponent<LineRenderer>();
		pointerTrailRend.SetVertexCount(MAX_TRAIL_LENGTH);

		pointerTrailPoints = new Queue<Vector3>(MAX_TRAIL_LENGTH);
		pointerTrailDict = new Dictionary<Vector3, bool>();

		parentPainting = GameObject.Find("Painting").transform;
		augmentedCamera = GameObject.Find("Painting Camera").GetComponent<Camera>();

		ChangeColor();
	}

	public void ChangeColor() {;
		lerpedColor = Color.Lerp(Color.red, Color.blue, transition += transitionRate);
		if (transition > 1) { transition = 0; }

		Debug.Log(lerpedColor);
	}

	public void Extend(float distance) {
		float newLength = distance * EXTENSION_FACTOR;
		pointerLength = newLength > MIN_EXTENSION ? newLength : MIN_EXTENSION;
	}

	private Vector3 Location() {
		Ray ray = augmentedCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

		return ray.origin + ray.direction * pointerLength;
	}

	void Update() {
		Vector3 location = Location();

		// Pointer Trail
		if(!pointerTrailDict.ContainsKey(location) && pointerTrailPoints.Count < MAX_TRAIL_LENGTH) {
			pointerTrailDict[location] = true;
			pointerTrailPoints.Enqueue(location);
		}

		if(pointerTrailPoints.Count > MIN_TRAIL_LENGTH) {
			Vector3 tail = pointerTrailPoints.Dequeue();
			pointerTrailDict[tail] = false;
		}

		Vector3[] trail = new Vector3[pointerTrailPoints.Count];
		Array.Copy(pointerTrailPoints.ToArray(), 0, trail, 0, trail.Length);
		pointerTrailRend.SetVertexCount(trail.Length);
		pointerTrailRend.SetPositions(trail);
	}

	public void Paint() {
		Vector3 location = Location();

		if(!endPoints.ContainsKey(location)) {
			endPoints[location] = true;

// START COROUTINE FOR THIS???
			// GameObject newDot = Instantiate(dot, endPoint, Quaternion.identity, parentPainting) as GameObject;
			// newDot.GetComponent<Renderer>().material.color = lerpedColor;

			wavePoints.Add(location);
			
			lineWave.SetVertexCount(wavePoints.Count);
			lineWave.SetPosition(wavePoints.Count - 1, location);
		}
	}
}
