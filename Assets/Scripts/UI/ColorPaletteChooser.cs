using UnityEngine;

public class ColorPaletteChooser : MonoBehaviour {
	void Awake() {
    GameObject chooserButton = GameObject.Find("Color Palette Button");

		// itemChooser = Util.LoadAndCreatePrefab(ITEM_CHOOSER_PREFAB, transform)
		// 	.GetComponent<ItemChooser>();

		// itemChooser.Initialize(PaintbrushType.ItemTypes());
		// itemChooser.OnItemChange += ChangeBrushType;
		ColorPalette colorPalette = GameObject.Find("Color Palette").GetComponent<ColorPalette>();
		colorPalette.OnColorPicked += ChangeColor;
		colorPalette.OnSelectionFinished += Close;
		
		chooserButton.GetComponent<ChooserButton>().OnClick += ToggleActive;
  }

	public void ChangeColor(Color color) {
		//TODO Delegate this
		PaintingGameManager.instance.Painting().ChangeColor(color);
	}

	public void Close() {
		gameObject.SetActive(false);
	}

  public void ToggleActive() {
    gameObject.SetActive(!gameObject.activeSelf);
  }
}
