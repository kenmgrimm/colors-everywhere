using UnityEngine;
using System.Collections.Generic;
using System.Text;

// API for communication with Server

[System.Serializable]
public class Painting {
  private static Encoding encoding;
  
  private int id;
  [SerializeField] private float latitude;
  [SerializeField] private float longitude;
  [SerializeField] private float direction_degrees;

  [SerializeField] public List<Stroke> strokes;
  

  public Painting(float latitude, float longitude, float directionDegrees) {
    encoding = new System.Text.UTF8Encoding();
    this.latitude = latitude;
    this.longitude = longitude;
    this.direction_degrees = directionDegrees;

    strokes = new List<Stroke>();
  }

  public void AddStroke(Stroke stroke) {
    strokes.Add(stroke);
    Debug.Log("Add(Stroke): ");
    Debug.Log(this.strokes.Count);
  }

  public void AddPoint(Vector3 point) {
    Debug.Log("AddPoint2: ");
    Debug.Log(point);
    strokes[0].AddPoint(point);
    Debug.Log(strokes[0].points[0].x);
  }

  public string ToJsonStr() {
    return JsonUtility.ToJson(this);
  }
}
