using UnityEngine;

public class Stroke : MonoBehaviour {
  private StrokeData strokeData;

	void Start () {}

  public void Initialize(PaintbrushType brushType, Color color, float width) {
    //@TODO  represent everything as PaintbrushTypes
    strokeData = new StrokeData(color, brushType.BrushType(), width);

    StrokeRenderer().SetRenderer(brushType.CreateRendererInstance());
    
    StrokeRenderer().ChangeColor(color);
    StrokeRenderer().SetWidth(width);
  }

  public void Initialize(StrokeData strokeData) {
    this.strokeData = strokeData;
    
    PaintbrushType paintbrushType = PaintbrushType.FindById(strokeData.brush_type); 
    
    StrokeRenderer().SetRenderer(paintbrushType.CreateRendererInstance());
    StrokeRenderer().ChangeColor(strokeData.color);
    StrokeRenderer().SetWidth(strokeData.brush_width);

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