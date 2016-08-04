using UnityEngine;
using UnityEngine.EventSystems;

public class PaintButton : EventTrigger {
	void Start () {}

	public override void OnPointerClick( PointerEventData data ) {
		GetComponent<Paint>().StartPainting();
	}
}
