using UnityEngine;
using System.Collections.Generic;

public class Painting : MonoBehaviour {
	private static string MODEL_PREFAB = "Model";
	private static string STROKE_PREFAB = "Stroke";
	
	public bool Dirty { get; set; }

	private List<Model> models;

	private List<Stroke> strokes;

	public PaintingData paintingData;

	private GameObject modelPrefab;

	private GameObject strokePrefab;

	void Awake () {
		models = new List<Model>();
		
		modelPrefab = Util.LoadPrefab(MODEL_PREFAB);

		strokePrefab = Util.LoadPrefab(STROKE_PREFAB);
		strokes = new List<Stroke>();
	}

	public void Load(int paintingId) {
		Debug.Log("Loading painting: " + paintingId);
		GetComponent<PaintingPersistence>().LoadPaintingData(paintingId);
	}
	
	public void Initialize(string jsonData) {
		strokes.Clear();
		paintingData.Load(jsonData);

		foreach(StrokeData data in paintingData.strokeDatas) {
			Stroke stroke = Instantiate(strokePrefab).GetComponent<Stroke>();
			stroke.transform.parent = transform;

			stroke.Initialize(data);
			strokes.Add(stroke);
		}
	}

	public void Initialize(float latitude, float longitude, int directionDegrees) {
		strokes.Clear();
		paintingData = new PaintingData(latitude, longitude, directionDegrees);
	}

	public void AddModel(Model model) {
		models.Add(model);
	}

	public void StartStroke(Color color, int brushType, float brushWidth) {
		Stroke stroke = Instantiate(strokePrefab).GetComponent<Stroke>();
		stroke.transform.parent = transform;

		stroke.Initialize(color, brushType, brushWidth);
		strokes.Add(stroke);

		paintingData.StartStroke(stroke);

		Dirty = true;
	}

	public Stroke CurrentStroke() {
		return strokes[strokes.Count - 1];
	}

	public void ChangeColor(Color color) {
		GameObject.Find("Brush").GetComponent<Brush>().ChangeColor(color);
	}

	public void AddPoint(Vector3 point) {
		CurrentStroke().AddPoint(point);
		Dirty = true;
	}

	public PaintingData PaintingData() {
		return paintingData;
	}

	public string ToJsonStr() {
		return paintingData.ToJsonStr();
	}

	public bool IsNew() {
		return paintingData.IsNew();
	}

	public int Id() {
		return paintingData.Id();
	}
}
