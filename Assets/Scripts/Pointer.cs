using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


// Smooth curve through points
//   http://answers.unity3d.com/questions/392606/line-drawing-how-can-i-interpolate-between-points.html
public class Pointer : MonoBehaviour {
	private static float MIN_EXTENSION = 0.01f;  // I think should be >= near clipping plane 
	private static float EXTENSION_FACTOR = 3f;

	private float pointerLength;
	// private LineRenderer line;
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

	void Start() {
		// Need to set starting pointerLength using extension slider.  Refactor and de-couple some of this stuff
		// DE-COUPLE
		float sliderValue = GameObject.Find("Extension Slider").GetComponent<Slider>().value;
		Extend(sliderValue);
		
		lineWave = GameObject.Find("Line Wave Auto").GetComponent<LineRenderer>();
		wavePoints = new List<Vector3>();

		parentPainting = GameObject.Find("Painting").transform;
		augmentedCamera = GameObject.Find("Painting Camera").GetComponent<Camera>();
		endPoints = new Dictionary<Vector3, bool>();
		// line = GetComponent<LineRenderer>();
		// line.SetPosition(0, Camera.main.transform.position + new Vector3(0, -0.1f, 0));
    
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

	public void Paint() {
		RaycastHit hit;
		// Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Ray ray = augmentedCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		// Vector3 pointerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + (Camera.main.transform.forward * POINTER_LENGTH));
		// Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
		
		Vector3 endPoint = ray.origin + ray.direction * pointerLength;

		if(!endPoints.ContainsKey(endPoint)) {
			endPoints[endPoint] = true;

// START COROUTINE FOR THIS???
			// GameObject newDot = Instantiate(dot, endPoint, Quaternion.identity, parentPainting) as GameObject;
			// newDot.GetComponent<Renderer>().material.color = lerpedColor;

			wavePoints.Add(endPoint);
			
			lineWave.SetVertexCount(wavePoints.Count);
			lineWave.SetPosition(wavePoints.Count - 1, endPoint);
		}
	}

	void Update () {}
}
