using UnityEngine;
using UnityEngine.EventSystems;

public class PaintButton : EventTrigger {
	private float PAINT_DROP_PER_SECOND = 20f;
	
	private GameObject brush;
	private bool isPainting = false;

	void Start () {
		brush = GameObject.Find("Brush");

		InvokeRepeating("Paint", 0, 1f / PAINT_DROP_PER_SECOND);
	}

	void Paint() {
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