using UnityEngine;

public class Model : MonoBehaviour {
  private ModelData modelData;

  void Start() {}
  
  public void Initialize(int modelType, Vector3 position, Quaternion orientation, Color color) {
    modelData = new ModelData(modelType, position, orientation, color);
    SetPosition(position);
    SetRotation(orientation);
    SetColor(color);
  }

  public ModelData ModelData() {
    Debug.Log("ModelData() : " + modelData.position);
    
    return modelData;
  }

  public void SetPosition(Vector3 position) {
    // Debug.Log("SetPosition: " + position);
    transform.position = position;
    modelData.position = position;
  }

  public void SetRotation(Quaternion rotation) {
    transform.rotation = rotation;
    modelData.orientation = rotation;
  }

  public void SetColor(Color color) {
    modelData.color = color;
  }
}
