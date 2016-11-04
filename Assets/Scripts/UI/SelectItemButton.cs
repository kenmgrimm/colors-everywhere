using UnityEngine;
using UnityEngine.EventSystems;

public class SelectItemButton : MonoBehaviour, IPointerClickHandler {
	public delegate void OnClickHandler(ItemType buttonType);
  public event OnClickHandler OnClick;

	private ItemType buttonType;

	public void Initialize(ItemType buttonType){
Debug.Log("Init w/ " + buttonType.Name());
		this.buttonType = buttonType;
	} 

	public void OnPointerClick(PointerEventData data) {
Debug.Log("Clicked: " + buttonType.Name());
		OnClick(buttonType);
	}
}
