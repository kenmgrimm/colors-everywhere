using UnityEngine;

public class ModelChooser : MonoBehaviour {
	private static string ITEM_CHOOSER_PREFAB = "Canvas - Item Chooser Overlay";
	
	ItemChooser itemChooser;

	void Awake() {
		itemChooser = Util.LoadAndCreatePrefab(ITEM_CHOOSER_PREFAB, transform)
			.GetComponent<ItemChooser>();

		itemChooser.Initialize(ModelType.ItemTypes());
Debug.Log("ModelChooser/Awake: Registering ChangeItem");
		itemChooser.OnItemChange += ChangeItem;
		
		GameObject chooserButton = GameObject.Find("Model Chooser Button");
		chooserButton.GetComponent<ChooserButton>().OnClick += itemChooser.ToggleActive;

		itemChooser.gameObject.SetActive(false);
  }

	public void ChangeItem(ItemType itemType) {
Debug.Log("ChangeItem: " + itemType.Name());








		// Delegate this
		GameObject.Find("Brush").GetComponent<ModelBrush>()
			.LoadNewBrushModel((ModelType)itemType);

		itemChooser.ToggleActive();
	}
}
