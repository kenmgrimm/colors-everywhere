using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class StrokeData : ISerializationCallbackReceiver {
  [SerializeField] private int brush_type;
  [SerializeField] public float brush_width;
  [SerializeField] public string color;
  
  [SerializeField] CondensedVector3[] serializedPoints;

  private List<Vector3> points = new List<Vector3>();

  [Serializable]
  public struct CondensedVector3 {
    public string x;
    public string y;
    public string z;

    public CondensedVector3(float x, float y, float z) {
      this.x = Math.Round((Decimal)x, 3).ToString();
      this.y = Math.Round((Decimal)y, 3).ToString();
      this.z = Math.Round((Decimal)z, 3).ToString();
    }
  }
  
  public void OnBeforeSerialize() {
    Debug.Log("OnBeforeSerialize");
    if(points == null) { return; }

    serializedPoints = new CondensedVector3[points.Count];

    for(int i = 0; i < points.Count; i++) {
      serializedPoints[i] = new CondensedVector3(points[i].x, points[i].y, points[i].z);
    }
  }

  public void OnAfterDeserialize() {
    Debug.Log("OnAfterDeserialize");
    if(serializedPoints == null) { return; }

    points = new List<Vector3>();

    for(int i = 0; i < serializedPoints.Length; i++) {
      CondensedVector3 point = serializedPoints[i];
      points.Add(new Vector3(float.Parse(point.x), float.Parse(point.y), float.Parse(point.z)));
    }
  }

  public StrokeData(string color, int brushType, float brushWidth) {
    this.brush_type = brushType;
    this.color = color;
    this.brush_width = brushWidth;
  }

  public void AddPoint(Vector3 point) {
    points.Add(point);
  }

  public List<Vector3> Points() { return points; }
}
