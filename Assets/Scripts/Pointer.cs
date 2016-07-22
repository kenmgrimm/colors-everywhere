using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pointer : MonoBehaviour {
	private float distance = 0.5f;
	private LineRenderer line;
	private Dictionary<Vector3, bool> endPoints;
	private Camera augmentedCamera;

	private Renderer rend;
	private Color lerpedColor;

	public GameObject dot;

	void Start() {
		augmentedCamera = GameObject.Find("Augmented Camera").GetComponent<Camera>();
		endPoints = new Dictionary<Vector3, bool>();
		line = GetComponent<LineRenderer>();
		line.SetPosition(0, Camera.main.transform.position + new Vector3(0, -0.1f, 0));
		
    rend = GameObject.Find("Painted Dot Yellow").GetComponent<Renderer>();
	}

	public void ChangeColor() {
		lerpedColor = Color.Lerp(Color.white, Color.blue, Mathf.PingPong(Time.time, 0.1f));
		rend.material.color = lerpedColor;
	}

	public void ChangeDistance() {
		distance += 0.2f;
		if(distance > 3) {
			distance = 0.5f;
		}
	}

	public void Paint() {
		RaycastHit hit;
		// Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Ray ray = augmentedCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		// Vector3 pointerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + (Camera.main.transform.forward * POINTER_LENGTH));
		// Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
		
		Vector3 endPoint = ray.origin + ray.direction * distance;
		
		line.SetPosition(1, endPoint);

		if(!endPoints.ContainsKey(endPoint)) {
			endPoints[endPoint] = true;

			Instantiate(dot, endPoint, Quaternion.identity);
		}
		// if(Physics.Raycast(ray, out hit)) {
		// 	Debug.Log(hit.transform.name);
		// }

	}

	void Update () {}
}
