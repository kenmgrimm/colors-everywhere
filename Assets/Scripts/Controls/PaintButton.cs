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
			brush.GetComponent<PaintBrush>().AddPoint();
		}
	}

	// Event Handlers
	public override void OnPointerDown(PointerEventData data) {
		brush.GetComponent<PaintBrush>().StartStroke();
		isPainting = true;
	}

	public override void OnPointerUp(PointerEventData data) {
		isPainting = false;
	}
	
	public override void OnPointerClick(PointerEventData data) {
		// OnPoin
	}

	public override void OnPointerEnter(PointerEventData eventData) { 
		if (Input.GetMouseButton(0)) {
			isPainting = true;
		} 
	}

	public override void OnPointerExit(PointerEventData data) {
		isPainting = false;
	}
}