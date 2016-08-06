using UnityEngine.EventSystems;

public class PaintButton : EventTrigger {
	void Start () {}

	public override void OnPointerDown(PointerEventData data) {
		GetComponent<Paint>().StartPainting();
	}

	public override void OnPointerUp(PointerEventData data) {
		GetComponent<Paint>().StopPainting();
	}
}
