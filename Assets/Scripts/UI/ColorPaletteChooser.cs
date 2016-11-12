using UnityEngine;

public class ColorPaletteChooser : MonoBehaviour {

	void Awake() {
    GameObject chooserButton = GameObject.Find("Color Palette Button");

		Util.LoadAndCreatePrefab("UI/Canvas - Color Palette Overlay", transform);

		ColorPalette colorPalette = GameObject.Find("Color Palette").GetComponent<ColorPalette>();
		colorPalette.OnColorPicked += ChangeColor;
		colorPalette.OnSelectionFinished += Close;
		
		chooserButton.GetComponent<ChooserButton>().OnClick += ToggleActive;

		Close();
  }

	void Start() {}

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
