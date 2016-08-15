using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class StrokeData {
  [SerializeField] private int id;
  [SerializeField] private int brush_type;
  [SerializeField] public string color;
  [SerializeField] public float brush_width;
  
  [SerializeField] public List<Vector3> points;

  public StrokeData(string color, int brushType, float brushWidth) {
    this.brush_type = brushType;
    this.color = color;
    this.brush_width = brushWidth;

    points = new List<Vector3>();
  }

  public void AddPoint(Vector3 point) {
    points.Add(point);
  }
}
