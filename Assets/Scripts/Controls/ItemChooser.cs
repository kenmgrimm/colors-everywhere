using System.Collections.Generic;
using UnityEngine;

public class ItemChooser : MonoBehaviour {
	public delegate void LoadHandler(ItemType itemType);
  public event LoadHandler OnItemChange;


  public void Initialize(List<ItemType> itemTypes) {
    
  }

  public void ToggleActive() {
    gameObject.SetActive(!gameObject.activeSelf);
  }
}
