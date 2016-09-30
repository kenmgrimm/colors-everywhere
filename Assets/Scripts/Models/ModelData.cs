using UnityEngine;
using System;

// Should be using compressed vector
[Serializable]
public class ModelData : ISerializationCallbackReceiver {
  [SerializeField] public int model_type;
  [SerializeField] public Quaternion orientation;
  [SerializeField] public Color color;
  [SerializeField] public Vector3 position;
  
  public ModelData(int modelType, Vector3 position, Quaternion orientation, Color color) {
    this.model_type = modelType;
    this.position = position;
    this.orientation = orientation;
    this.color = color;
  }

  public void OnBeforeSerialize() {
    // if(points == null) { return; }

    // serializedPoints = new CompressedVector3[points.Count];

    // for(int i = 0; i < points.Count; i++) {
    //   serializedPoints[i] = new CompressedVector3(points[i].x, points[i].y, points[i].z);
    // }
  }

  public void OnAfterDeserialize() {
    // if(serializedPoints == null) { return; }

    // points = new List<Vector3>();

    // for(int i = 0; i < serializedPoints.Length; i++) {
    //   CompressedVector3 point = serializedPoints[i];
    //   points.Add(new Vector3(float.Parse(point.x), float.Parse(point.y), float.Parse(point.z)));
    // }
  }
}
