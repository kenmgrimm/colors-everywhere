using UnityEngine;

public class Painting : MonoBehaviour {
	private static string STROKE_PREFAB = "Stroke";
	public PaintingData paintingData;
	private PaintingRenderer paintingRenderer;
	private GameObject strokePrefab;

	void Start () {
		paintingRenderer = GetComponent<PaintingRenderer>();
		paintingData = new PaintingData(2.1f, 2.1f, 10);

		strokePrefab = Util.LoadPrefab(STROKE_PREFAB);
	}
	void Update () {}

	public void StartStroke(string color, int brushType, float brushWidth) {
		
		// MonoBehaviours
		
		Stroke stroke = Instantiate(strokePrefab).GetComponent<Stroke>();
		stroke.Initialize(color, brushType, brushWidth);

		Debug.Log("*###*#*");
		Debug.Log(stroke.StrokeData().color);

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
