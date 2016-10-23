using UnityEngine;
using UnityEngine.EventSystems;

public class ColorButton : EventTrigger {
	private ColorWheel colorWheel;

	void Awake () {
		GameObject colorWheelObj = GameObject.Find("Color Wheel");
		colorWheel = colorWheelObj.GetComponent<ColorWheel>();
		colorWheelObj.SetActive(false);
	}

	public override void OnPointerClick( PointerEventData data ) {
		colorWheel.TogglePalette();
	}
}
