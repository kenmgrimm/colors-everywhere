using UnityEngine;

public class PaintbrushChooser : MonoBehaviour {
	private static string ITEM_CHOOSER_PREFAB = "Canvas - Item Chooser Overlay";
	
	ItemChooser itemChooser;

	void Awake() {
    GameObject chooserButton = GameObject.Find("Paintbrush Chooser Button");

		itemChooser = Util.LoadAndCreatePrefab(ITEM_CHOOSER_PREFAB, transform)
			.GetComponent<ItemChooser>();

		itemChooser.Initialize(ModelType.ItemTypes());
		itemChooser.OnItemChange += ChangeItem;
		
		chooserButton.GetComponent<ChooserButton>().OnClick += itemChooser.ToggleActive;

		itemChooser.gameObject.SetActive(false);
  }

	public void ChangeItem(ItemType itemType) {
		// GameObject.Find("Brush").GetComponent<ModelBrush>().LoadNewBrushModel(itemType);

		itemChooser.ToggleActive();
	}
}
