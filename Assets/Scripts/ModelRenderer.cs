using UnityEngine;
using System.Collections.Generic;

public class ModelRenderer : MonoBehaviour {
	private GameObject brushPrefab;
	private List<Vector3> strokePoints;

	private Dictionary<Vector3, bool> pointerTrailDict;

	void Awake () {
		brushPrefab = Util.LoadPrefab("Tree_04_05");
		strokePoints = new List<Vector3>();
	}

	public void ChangeColor(Color color) {}
	
  public void AddPoint(Vector3 point) {
		strokePoints.Add(point);
		Instantiate(brushPrefab, point, Quaternion.identity);
	}
}
