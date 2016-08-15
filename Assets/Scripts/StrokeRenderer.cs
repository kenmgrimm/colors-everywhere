using UnityEngine;
using System;
using System.Collections.Generic;

public class StrokeRenderer : MonoBehaviour {
  private const int MIN_TRAIL_LENGTH = 5;
	private const int MAX_TRAIL_LENGTH = 10;

	private LineRenderer lineWave;
	private List<Vector3> wavePoints;

	private Dictionary<Vector3, bool> pointerTrailDict;
	private Queue<Vector3> pointerTrailPoints;
	private LineRenderer pointerTrailRend;

	void Awake () {
		lineWave = GameObject.Find("Line Wave Auto").GetComponent<LineRenderer>();
		wavePoints = new List<Vector3>();

		pointerTrailRend = GameObject.Find("Pointer Trail").GetComponent<LineRenderer>();
		pointerTrailRend.SetVertexCount(MAX_TRAIL_LENGTH);

		pointerTrailPoints = new Queue<Vector3>(MAX_TRAIL_LENGTH);
		pointerTrailDict = new Dictionary<Vector3, bool>();
	}
	
	void Update () {}
	
  public void AddPoint(Vector3 point) {
		if(pointerTrailPoints.Count < MAX_TRAIL_LENGTH) {
			pointerTrailDict[point] = true;
			pointerTrailPoints.Enqueue(point);
		}

		if(pointerTrailPoints.Count > MIN_TRAIL_LENGTH) {
			Vector3 tail = pointerTrailPoints.Dequeue();
			pointerTrailDict[tail] = false;
		}

		Vector3[] trail = new Vector3[pointerTrailPoints.Count];
		Array.Copy(pointerTrailPoints.ToArray(), 0, trail, 0, trail.Length);
		pointerTrailRend.SetVertexCount(trail.Length);
		pointerTrailRend.SetPositions(trail);
	
		wavePoints.Add(point);

		lineWave.SetVertexCount(wavePoints.Count);
		lineWave.SetPosition(wavePoints.Count - 1, point);
	}
}
