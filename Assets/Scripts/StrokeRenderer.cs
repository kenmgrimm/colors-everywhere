using UnityEngine;
using System.Collections.Generic;

public class StrokeRenderer : MonoBehaviour {
	private LineRenderer lineRenderer;
	private List<Vector3> strokePoints;

	private Dictionary<Vector3, bool> pointerTrailDict;

	void Awake () {
		GameObject line = Util.LoadAndCreatePrefab("Line Fire", transform);
		lineRenderer = line.GetComponent<LineRenderer>(); 

		strokePoints = new List<Vector3>();
	}

	public void ChangeColor(Color color) {
		lineRenderer.SetColors(color, color);
	}
	
  public void AddPoint(Vector3 point) {
		strokePoints.Add(point);

		lineRenderer.SetVertexCount(strokePoints.Count);
		lineRenderer.SetPosition(strokePoints.Count - 1, point);
	}
}
