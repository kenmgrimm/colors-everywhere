using UnityEngine;
using UnityEngine.EventSystems;

public class ChooserButton : MonoBehaviour, IPointerClickHandler {
	public delegate void OnClickHandler ();
  public event OnClickHandler OnClick;

  public void OnPointerClick(PointerEventData data) {
    if(OnClick == null) { return; }
    
		OnClick();
  }
}
