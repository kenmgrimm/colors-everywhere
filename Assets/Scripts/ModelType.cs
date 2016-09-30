using System.Collections.Generic;
using UnityEngine;

public class ModelType {
  private int id;
  private string typeName;
  private string modelFile;
  private string iconFile;

  private GameObject modelPrefab;
  private GameObject modelViewPrefab;

  public ModelType (int id, string typeName, string modelFile, string iconFile) {
    this.id = id;
    this.typeName = typeName;
    this.modelFile = modelFile;
    this.iconFile = iconFile;

    modelPrefab = Util.LoadPrefab("Model");

    modelViewPrefab = Util.LoadPrefab("models/" + modelFile);
  }

  public static ModelType FindById(int id) {
    return new ModelType(0, "Wobbly Tree", "tree_04_05", "None Yet"); 
  }

  public GameObject CreateInstance(ModelData modelData) {
    return CreateInstance(modelData.position, modelData.orientation, modelData.color, null);
  }


  public GameObject CreateInstance(Vector3 position, Quaternion orientation, Color color, Transform parent) {
    GameObject model = (GameObject)GameObject.Instantiate(modelPrefab, parent);
    model.GetComponent<Model>().Initialize(id, position, orientation, color);

    GameObject modelView = (GameObject)GameObject.Instantiate(modelViewPrefab, model.transform);
    
    // Why is this necessary?  The prefab should have these already at zero?
    modelView.transform.localPosition = Vector3.zero;
    modelView.transform.localRotation = Quaternion.identity;

    return model;
  }
}
