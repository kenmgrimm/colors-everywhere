using UnityEngine;

public class Model : MonoBehaviour {
	private static float SCALE_UP_FACTOR = 1.5f;
	private static float SCALE_DOWN_FACTOR = 1.0f / SCALE_UP_FACTOR;
	private static float MAX_SCALE = 20f;
	private static float MIN_SCALE = 0.2f;

  private float scale = 1.0f;

  private static GameObject modelPrefab;

  public ModelData modelData;
  private GameObject modelView;

  void Awake() { }

  public static GameObject CreateInstance(ModelData modelData) {
    ModelType modelType = ModelType.FindById(modelData.model_type);

    return CreateInstance(modelType, modelData.position, modelData.orientation, modelData.scale, modelData.color, null);
  }

  public static GameObject CreateInstance(ModelType modelType, Vector3 position, Quaternion orientation, Vector3 scale, Color color, Transform parent) {
    GameObject model = (GameObject)GameObject.Instantiate(ModelPrefab(), null);

    model.GetComponent<Model>().Initialize(modelType, position, orientation, scale, color);

    return model;
  }

  public void Initialize(ModelType modelType, Vector3 position, Quaternion orientation, Vector3 scale, Color color) {
    modelData = new ModelData(modelType.id, position, orientation, scale, color);

    GameObject modelViewPrefab = Util.LoadPrefab("Models/" + modelType.modelFile);

    GameObject modelView = (GameObject)GameObject.Instantiate(modelViewPrefab, transform);
    
    // Why is this necessary?  The prefab should have these already at zero?
    modelView.transform.localPosition = Vector3.zero;
    modelView.transform.localRotation = Quaternion.identity;

    transform.position = position;
    transform.rotation = orientation;
    transform.localScale = scale;    
  }

  private static GameObject ModelPrefab() {
    if(!modelPrefab) {
      modelPrefab = Util.LoadPrefab("Model");
    }
    return modelPrefab;
  }

  public ModelData ModelData() {
    return modelData;
  }

  public void SetPosition(Vector3 position) {
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

  public void ScaleUp() {
    AdjustScale(SCALE_UP_FACTOR);
  }

  public void ScaleDown() {
    AdjustScale(SCALE_DOWN_FACTOR);
  }

  private void AdjustScale(float scaleFactor) {
    scale *= scaleFactor;

    if(scale > MAX_SCALE) {
      scale = MAX_SCALE;
    } else if(scale < MIN_SCALE) {
      scale = MIN_SCALE;
    }

    transform.localScale = Vector3.one * scale;
    modelData.scale = transform.localScale;
  }
}
