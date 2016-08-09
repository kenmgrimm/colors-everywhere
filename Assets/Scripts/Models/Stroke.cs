using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Stroke {
  private int id;
  [SerializeField] private int brush_type;
  [SerializeField] public string color;
  
  [SerializeField] public List<Vector3> points;

  public Stroke(int brushType, string color) {
    this.brush_type = brushType;
    this.color = color;

    points = new List<Vector3>();
  }

  public void AddPoint(Vector3 point) {
    Debug.Log("AddPoint: " + point);
    points.Add(point);
    Debug.Log(points[0].x);
  }
}
