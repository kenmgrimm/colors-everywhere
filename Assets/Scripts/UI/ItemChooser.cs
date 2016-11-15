using System.Collections.Generic;
using UnityEngine;

public class ItemChooser : MonoBehaviour {
	public delegate void ItemChangeHandler(ItemType itemType);
  public event ItemChangeHandler OnItemChange;

  public void Initialize(List<ItemType> itemTypes) {









    var grid = GameObject.Find("Item Chooser Grid");






Debug.Log("Initialize: Grid: " + grid.name);
    var slotFab = Util.LoadPrefab("UI/Item Chooser Slot");
Debug.Log("Initialize: slotFab: " + slotFab.name);

    foreach(ItemType itemType in itemTypes) {
      Debug.Log("itemType: " + itemType.Name());

      var slotGameObject = (GameObject)Instantiate(slotFab,  grid.transform);
      
      var button = slotGameObject.GetComponent<SelectItemButton>();
      button.Initialize(itemType);

      button.OnClick += ItemSelected;
    }
  }

  public void ItemSelected(ItemType itemType) {
Debug.Log("ItemSelected: " + itemType.Name());
    if(OnItemChange == null) { return; }
    
    OnItemChange(itemType);
  }

  public void ToggleActive() {
    gameObject.SetActive(!gameObject.activeSelf);
  }
}
