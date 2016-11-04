using System.Collections.Generic;
using UnityEngine;

public class ItemChooser : MonoBehaviour {
	public delegate void ItemChangeHandler(ItemType itemType);
  public event ItemChangeHandler OnItemChange;

  public void Initialize(List<ItemType> itemTypes) {
    var grid = GameObject.Find("Item Chooser Grid");

    foreach(ItemType itemType in itemTypes) {
      var slotGameObject = Util.LoadAndCreatePrefab("UI/Item Chooser Slot", grid.transform);
      
      var button = slotGameObject.GetComponent<SelectItemButton>();
      button.Initialize(itemType);

      button.OnClick += ItemSelected;
    }
  }

  public void  ItemSelected(ItemType itemType) {
Debug.Log("ItemSelected: " + itemType.Name());
    OnItemChange(itemType);
  }

  public void ToggleActive() {
    gameObject.SetActive(!gameObject.activeSelf);
  }
}
