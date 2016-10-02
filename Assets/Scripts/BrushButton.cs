using UnityEngine;
using UnityEngine.EventSystems;

public class BrushButton : EventTrigger {
	private ModelBrush brush;
	private int brushNum = 0;

	void Start () {
		brush = GameObject.Find("Brush").GetComponent<ModelBrush>();
	}

	public override void OnPointerClick( PointerEventData data ) {
		brush.LoadNextBrushModel();
	}
}
