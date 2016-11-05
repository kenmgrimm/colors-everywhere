using UnityEngine;
using UnityEngine.EventSystems;

public class ModelButton : EventTrigger {
	private GameObject brush;
	private bool isPressed = false;

	void Start () {
		brush = GameObject.Find("Model Brush");
	}

	// Event Handlers
	public override void OnPointerDown(PointerEventData data) {
		if(!isPressed) {
			brush.GetComponent<ModelBrush>().OnButtonPress();
		
			isPressed = true;
		}
	}

	public override void OnPointerUp(PointerEventData data) {
		isPressed = false;
	}
	
	public override void OnPointerClick(PointerEventData data) {}

	public override void OnPointerEnter(PointerEventData eventData) {
		isPressed = false;
	}

	public override void OnPointerExit(PointerEventData data) {
		isPressed = false;
	}
}