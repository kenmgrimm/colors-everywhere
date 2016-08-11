using UnityEngine;

public class Painting : MonoBehaviour {
	private static string STROKE_PREFAB = "Stroke";
	public PaintingData paintingData;
	private PaintingRenderer paintingRenderer;
	private GameObject strokePrefab;

	void Start () {
		paintingRenderer = GetComponent<PaintingRenderer>();


		
		
		// lat, long, direction hard-coded
		paintingData = new PaintingData(latitude: 2.1f, longitude: 2.1f, directionDegrees: 10);

		strokePrefab = Util.LoadPrefab(STROKE_PREFAB);
	}
	void Update () {}

	public void StartStroke(string color, int brushType, float brushWidth) {
		Stroke stroke = Instantiate(strokePrefab).GetComponent<Stroke>();
		stroke.Initialize(color, brushType, brushWidth);

		paintingRenderer.StartStroke(stroke);
		paintingData.StartStroke(stroke);
	}

	public void AddPoint(Vector3 point) {
		paintingRenderer.AddPoint(point);
		paintingData.AddPoint(point);
	}

	public PaintingData PaintingData() {
		return paintingData;
	}

	public string ToJsonStr() {
		return paintingData.ToJsonStr();
	}
}
