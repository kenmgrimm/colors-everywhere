using UnityEngine;

public class Stroke : MonoBehaviour {
  private StrokeData strokeData;
  private StrokeRenderer strokeRenderer;

	void Start () {}

  public void Initialize(string color, int brushType, float brushWidth) {
    strokeRenderer = GetComponent<StrokeRenderer>();
    strokeData = new StrokeData(color, brushType, brushWidth);

    strokeRenderer.StartStroke();
  }

	public void AddPoint(Vector3 point) {
    strokeRenderer.AddPoint(point);
    strokeData.AddPoint(point);
	}

  // Remove following testing
  public StrokeData StrokeData() {
    return strokeData;
  }
}