using UnityEngine;

public class PaintingRenderer : MonoBehaviour {
	private Stroke currentStroke;

	void Start () {}
	
	void Update () {}

	public void StartStroke(Stroke stroke) {
		Debug.Log("Start(Stroke)2: ");
		Debug.Log(stroke);
		currentStroke = stroke;
	}
	public void AddPoint(Vector3 point) {
		currentStroke.AddPoint(point);
	}

	private PaintingData PaintingData() {
		return GetComponent<PaintingData>();
	}
}
