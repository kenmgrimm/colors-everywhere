using UnityEngine;
using System;
using System.Collections.Generic;

public class StrokeRenderer : MonoBehaviour {
  private const int MIN_TRAIL_LENGTH = 5;
	private const int MAX_TRAIL_LENGTH = 10;

	private LineRenderer lineRenderer;
	private List<Vector3> strokePoints;

	private Dictionary<Vector3, bool> pointerTrailDict;
	private Queue<Vector3> pointerTrailPoints;
	private LineRenderer pointerTrailRenderer;

	void Awake () {
		GameObject line = Util.LoadAndCreatePrefab("Line Fire", transform);
		lineRenderer = line.GetComponent<LineRenderer>(); 

		strokePoints = new List<Vector3>();

		pointerTrailRenderer = GameObject.Find("Pointer Trail").GetComponent<LineRenderer>();
		pointerTrailRenderer.SetVertexCount(MAX_TRAIL_LENGTH);

		pointerTrailPoints = new Queue<Vector3>(MAX_TRAIL_LENGTH);
	}
	
	void Update () {}
	
  public void AddPoint(Vector3 point) {
		UpdatePointerTrail(point);
	
		strokePoints.Add(point);

		lineRenderer.SetVertexCount(strokePoints.Count);
		lineRenderer.SetPosition(strokePoints.Count - 1, point);
	}

	private void UpdatePointerTrail(Vector3 point) {
		if(pointerTrailPoints.Count < MAX_TRAIL_LENGTH) {
			pointerTrailPoints.Enqueue(point);
		}
		else if(pointerTrailPoints.Count > MIN_TRAIL_LENGTH) {
			pointerTrailPoints.Dequeue();
		}

		Vector3[] trail = new Vector3[pointerTrailPoints.Count];
		Array.Copy(pointerTrailPoints.ToArray(), 0, trail, 0, trail.Length);

		pointerTrailRenderer.SetVertexCount(trail.Length);
		pointerTrailRenderer.SetPositions(trail);
	}
}
