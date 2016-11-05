using UnityEngine;
using UnityEngine.EventSystems;

public class SelectItemButton : MonoBehaviour, IPointerClickHandler {
	public delegate void OnClickHandler(ItemType buttonType);
  public event OnClickHandler OnClick;

	private ItemType buttonType;

	public void Initialize(ItemType buttonType){
		this.buttonType = buttonType;
	} 

	public void OnPointerClick(PointerEventData data) {
		OnClick(buttonType);
	}
}
