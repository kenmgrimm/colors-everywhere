﻿using UnityEngine;
using System.Collections.Generic;

public class Painting : MonoBehaviour {
	private static string MODEL_PREFAB = "Model";
	private static string STROKE_PREFAB = "Stroke";
	
	public bool Dirty { get; set; }

	private List<Stroke> strokes;

	private PaintingData paintingData;

	private GameObject strokePrefab;

	void Awake () {
		strokes = new List<Stroke>();
		
		strokePrefab = Util.LoadPrefab(STROKE_PREFAB);
	}

	public void Load(int paintingId) {
		Debug.Log("Loading painting: " + paintingId);
		GetComponent<PaintingPersistence>().LoadPaintingData(paintingId);
	}
	
	public void Initialize(string jsonData) {
		strokes.Clear();
		//@TODO fix this need for a temporary object to load itself 
		paintingData = new PaintingData(1f, 1f, 30);
		paintingData.Load(jsonData);

		foreach(StrokeData data in paintingData.strokeDatas) {
			Stroke stroke = Instantiate(strokePrefab).GetComponent<Stroke>();
			stroke.transform.parent = transform;

			stroke.Initialize(data);
			strokes.Add(stroke);
		}

		Debug.Log("Initialize: " + jsonData); 
		List<ModelData> modelDatasClone = new List<ModelData>(paintingData.modelDatas);

		foreach(ModelData data in modelDatasClone) {
			ModelType modelType = ModelType.FindById(data.model_type);

			GameObject model = Model.CreateInstance(data, transform);

			AddModel(model.GetComponent<Model>());
		}
	}

	public void Initialize(float latitude, float longitude, int directionDegrees) {
		strokes.Clear();
		paintingData = new PaintingData(latitude, longitude, directionDegrees);
	}

	public void AddModel(Model model) {
		paintingData.AddModel(model);
		model.transform.parent = transform;

		Dirty = true;
	}

	public void StartStroke(Color color, PaintbrushType brushType, float brushWidth) {
		Stroke stroke = Instantiate(strokePrefab).GetComponent<Stroke>();
		stroke.transform.parent = transform;

		stroke.Initialize(brushType, color, brushWidth);
		strokes.Add(stroke);

		paintingData.StartStroke(stroke);

		Dirty = true;
	}

	public Stroke CurrentStroke() {
		return strokes[strokes.Count - 1];
	}

	public void ChangeColor(Color color) {
		//@TODO - needs to work for models as well
		GameObject.Find("Paint Brush").GetComponent<Brush>().ChangeColor(color);
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
