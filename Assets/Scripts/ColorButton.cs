using UnityEngine;
using UnityEngine.EventSystems;

public class ColorButton : EventTrigger {
	private GameObject brush;

	void Start () {
		brush = GameObject.Find("Brush");
	}

	public override void OnPointerClick( PointerEventData data ) {
		brush.GetComponent<BrushPointer>().ChangeColor();
	}
}


