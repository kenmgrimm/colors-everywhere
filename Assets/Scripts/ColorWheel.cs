using UnityEngine;
using UnityEngine.EventSystems;

public class ColorWheel : EventTrigger {
	private GameObject brush;

	void Start () {
		brush = GameObject.Find("Brush");
	}

	public void TogglePalette() {
		gameObject.SetActive(!gameObject.activeSelf);
	}

	public override void OnPointerClick( PointerEventData data ) {
		string color  = "AAAAAA";
		brush.GetComponent<BrushPointer>().ChangeColor(color);

		gameObject.SetActive(false);
	}
}
