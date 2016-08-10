using UnityEngine;
using System.Collections.Generic;
using System.Text;

// API for communication with Server

[System.Serializable]
public class PaintingData {
  private static Encoding encoding;
  
  private int id;
  [SerializeField] private float latitude;
  [SerializeField] private float longitude;
  [SerializeField] private float direction_degrees;

  [SerializeField] public List<StrokeData> strokes;
  

  public PaintingData(float latitude, float longitude, float directionDegrees) {
    encoding = new System.Text.UTF8Encoding();
    this.latitude = latitude;
    this.longitude = longitude;
    this.direction_degrees = directionDegrees;

    strokes = new List<StrokeData>();
  }

  public void StartStroke(Stroke stroke) {
    strokes.Add(stroke.StrokeData());
    Debug.Log("Start(Stroke): ");
    Debug.Log(stroke);
    Debug.Log(stroke.StrokeData());
    Debug.Log(strokes.Count);
    Debug.Log(strokes[0]);
  }

  public void AddPoint(Vector3 point) {
    Debug.Log("AddPoint2: ");
    Debug.Log(point);
    
    CurrentStroke().AddPoint(point);
  }

  public string ToJsonStr() {
    return JsonUtility.ToJson(this);
  }

  private StrokeData CurrentStroke() {
    return strokes[strokes.Count - 1];
  }
}
