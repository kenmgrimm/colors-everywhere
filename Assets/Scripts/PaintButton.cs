using UnityEngine;
using UnityEngine.EventSystems;

public class PaintButton : EventTrigger {
	private GameObject brush;

	private bool isPainting = false;

	void Start () {
		brush = GameObject.Find("Brush");
	}
	void Update() {
		if(isPainting) {
			brush.GetComponent<BrushPointer>().AddPoint();
		}
	}

	// Event Handlers
	public override void OnPointerDown(PointerEventData data) {
		brush.GetComponent<BrushPointer>().StartStroke();
		isPainting = true;
	}

	public override void OnPointerUp(PointerEventData data) {
		isPainting = false;
	}
	
}