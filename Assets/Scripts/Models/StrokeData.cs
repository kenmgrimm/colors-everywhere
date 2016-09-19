using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class StrokeData : ISerializationCallbackReceiver {
  [SerializeField] private int brush_type;
  [SerializeField] public float brush_width;
  [SerializeField] public Color color;
  
  [SerializeField] CompressedVector3[] serializedPoints;

  private List<Vector3> points = new List<Vector3>();

  public void OnBeforeSerialize() {
    if(points == null) { return; }

    serializedPoints = new CompressedVector3[points.Count];

    for(int i = 0; i < points.Count; i++) {
      serializedPoints[i] = new CompressedVector3(points[i].x, points[i].y, points[i].z);
    }
  }

  public void OnAfterDeserialize() {
    if(serializedPoints == null) { return; }

    points = new List<Vector3>();

    for(int i = 0; i < serializedPoints.Length; i++) {
      CompressedVector3 point = serializedPoints[i];
      points.Add(new Vector3(float.Parse(point.x), float.Parse(point.y), float.Parse(point.z)));
    }
  }

  public StrokeData(Color color, int brushType, float brushWidth) {
    this.brush_type = brushType;
    this.color = color;
    this.brush_width = brushWidth;
  }

  public void AddPoint(Vector3 point) {
    points.Add(point);
  }

  public List<Vector3> Points() { return points; }
}
