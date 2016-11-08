using UnityEngine;

public class PaintbrushChooser : MonoBehaviour {
	private static string ITEM_CHOOSER_PREFAB = "UI/Canvas - Item Chooser Overlay";
	
	ItemChooser itemChooser;

	void Awake() {
    GameObject chooserButton = GameObject.Find("Paintbrush Chooser Button");

		itemChooser = Util.LoadAndCreatePrefab(ITEM_CHOOSER_PREFAB, transform)
			.GetComponent<ItemChooser>();

		itemChooser.Initialize(PaintbrushType.ItemTypes());
		itemChooser.OnItemChange += ChangeBrushType;
		
		chooserButton.GetComponent<ChooserButton>().OnClick += itemChooser.ToggleActive;

		itemChooser.gameObject.SetActive(false);
  }

	public void ChangeBrushType(ItemType itemType) {
		//TODO Delegate this
		
		GameObject.Find("Paint Brush").GetComponent<PaintBrush>()
			.ChangeRenderer((PaintbrushType)itemType);

		itemChooser.ToggleActive();
	}
}
