using UnityEngine;
using UnityEngine.EventSystems;

public class ColorButton : EventTrigger {
	private GameObject pointer;

	void Start () {
		pointer = GameObject.Find("Paint Button");
	}

	public override void OnPointerClick( PointerEventData data ) {
		pointer.GetComponent<Pointer>().ChangeColor();
	}
}


