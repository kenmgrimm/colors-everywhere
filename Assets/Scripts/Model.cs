using UnityEngine;

public class Model : MonoBehaviour {
  private ModelData modelData;
  private GameObject modelPrefab;

	void Start () {}

  public Model(int modelType, Vector3 position, Quaternion orientation, Color color) {
    modelData = new ModelData(modelType, orientation, color, position);

    modelPrefab = Util.LoadPrefab("tree_04_05");

    GameObject.Instantiate(modelPrefab);
  }
}