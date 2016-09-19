using UnityEngine;

public class Model : MonoBehaviour {
  private ModelData modelData;

	void Start () {}

  // public void Initialize(Color color, int brushType, float brushWidth) {
  //   modelData = new ModelData(color, brushType, brushWidth);
  //   StrokeRenderer().ChangeColor(color);
  // }

  // public void Initialize(ModelData modelData) {
  //   this.modelData = modelData;
  //   StrokeRenderer().ChangeColor(strokeData.color);

  //   foreach(Vector3 point in strokeData.Points()) {
  //     StrokeRenderer().AddPoint(point);
  //   }
  // }

  // private StrokeRenderer StrokeRenderer() {
  //   return GetComponent<StrokeRenderer>();
  // }

	// public void AddPoint(Vector3 point) {
  //   StrokeRenderer().AddPoint(point);
  //   strokeData.AddPoint(point);
	// }

  // // Remove following testing
  // public StrokeData StrokeData() {
  //   return strokeData;
  // }
}