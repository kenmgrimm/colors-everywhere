using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class PaintingData {
  [SerializeField] public int id = -1;
  [SerializeField] private float latitude;
  [SerializeField] private float longitude;
  [SerializeField] private float direction_degrees;

  [SerializeField] public List<StrokeData> strokeDatas;
  [SerializeField] public List<ModelData> modelDatas;
  
  public PaintingData(float latitude, float longitude, float directionDegrees) {
    this.latitude = latitude;
    this.longitude = longitude;
    this.direction_degrees = directionDegrees;

    Debug.Log("Created PaintingData: " + latitude + ", " + longitude + ", " + direction_degrees);

    strokeDatas = new List<StrokeData>();
  }

  public void StartStroke(Stroke stroke) {
    strokeDatas.Add(stroke.StrokeData());
  }

  public void AddModel(Model model) {
    Debug.Log(model.ModelData().scale);
    modelDatas.Add(model.ModelData());
  }

  public void AddPoint(Vector3 point) {
    CurrentStrokeData().AddPoint(point);
  }

  public void Load(string jsonData) {
    strokeDatas = null;
    JsonUtility.FromJsonOverwrite(jsonData, this);
  }

  public string ToJsonStr() {
    Debug.Log(JsonUtility.ToJson(this));

    return JsonUtility.ToJson(this);
  }

  private StrokeData CurrentStrokeData() {
    return strokeDatas[strokeDatas.Count - 1];
  }

  public bool IsNew() {
    return id >= 0;
  }

  public int Id() {
    return id;
  }
}
