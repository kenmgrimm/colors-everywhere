using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Smooth curve through points
//   http://answers.unity3d.com/questions/392606/line-drawing-how-can-i-interpolate-between-points.html
public class Pointer : MonoBehaviour {
	private float distance = 0.1f;
	// private LineRenderer line;
	private Dictionary<Vector3, bool> endPoints;
	private Camera augmentedCamera;

	private Transform parentPainting;

	private Renderer rend;
	private Color lerpedColor;
	private float transitionRate = 0.1f;
	private float transition = 0f;

	public GameObject dot;

	void Start() {
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

	public void ChangeDistance() {
		// distance += 0.1f;
		// if(distance > 1) {
		// 	distance = 0.1f;
		// }
	}

	public void Paint() {
		RaycastHit hit;
		// Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Ray ray = augmentedCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		// Vector3 pointerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + (Camera.main.transform.forward * POINTER_LENGTH));
		// Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
		
		Vector3 endPoint = ray.origin + ray.direction * distance;
		
		// line.SetPosition(1, endPoint);

		if(!endPoints.ContainsKey(endPoint)) {
			endPoints[endPoint] = true;

// START COROUTINE FOR THIS???
			GameObject newDot = Instantiate(dot, endPoint, Quaternion.identity, parentPainting) as GameObject;
			newDot.GetComponent<Renderer>().material.color = lerpedColor;
		}
		// if(Physics.Raycast(ray, out hit)) {
		// 	Debug.Log(hit.transform.name);
		// }

	}

	void Update () {}
}
