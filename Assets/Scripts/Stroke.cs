using UnityEngine;

public class Stroke : MonoBehaviour {
  private StrokeData strokeData;

	void Start () {}

  public void Initialize(Color color, int brushType, float brushWidth) {
    strokeData = new StrokeData(color, brushType, brushWidth);
    StrokeRenderer().ChangeColor(color);
  }

  public void Initialize(StrokeData strokeData) {
    this.strokeData = strokeData;
    StrokeRenderer().ChangeColor(strokeData.color);

    foreach(Vector3 point in strokeData.Points()) {
      StrokeRenderer().AddPoint(point);
    }
  }

  private StrokeRenderer StrokeRenderer() {
    return GetComponent<StrokeRenderer>();
  }

	public void AddPoint(Vector3 point) {
    StrokeRenderer().AddPoint(point);
    strokeData.AddPoint(point);
	}

  // Remove following testing
  public StrokeData StrokeData() {
    return strokeData;
  }
}