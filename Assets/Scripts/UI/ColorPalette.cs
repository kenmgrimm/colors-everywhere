using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorPalette : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler {
	public PointerEventData pointerEvent;
	public Texture2D paletteTexture;
	private Color pickedColor;
	private Image pickedColorImage;

	public delegate void ColorPickedHandler(Color color);
	public event ColorPickedHandler OnColorPicked;

	public delegate void SelectionFinishedHandler();
	public event SelectionFinishedHandler OnSelectionFinished;

	void Awake() {	
		pickedColorImage = GameObject.Find("Picked Color").GetComponent<Image>();
		Rect rect = GetComponent<RectTransform>().rect;

		pickedColor = Color.white;

		Debug.Log("CP Awake");
		Debug.Log("Screen w x h: ratio (" + Screen.width + ", " + Screen.height + ") : " + (float)Screen.height / Screen.width);

		Debug.Log("Texture w x h: ratio (" + paletteTexture.width + ", " + paletteTexture.height + ") : " + (float)paletteTexture.height / paletteTexture.width);
		Debug.Log("Rect dimensions: (" + rect.xMin + ", " + rect.yMin + ") (" + rect.xMax + ", " + rect.yMax + ")");
		Debug.Log("Palette position (x, y): " + (int)transform.position.x + ", " + (int)transform.position.y + ")");
		Debug.Log("Scale factor: " + transform.parent.GetComponent<RectTransform>().localScale);
	}

	void Start() { }

	public void OnDrag( PointerEventData data ) {
		int convertedX = (int)(data.position.x - transform.position.x);

		int yPosFromBottomUp = (int)(transform.position.y - GetComponent<RectTransform>().rect.height);
		int convertedY = (int)(data.position.y - yPosFromBottomUp);


		// If modifying canvas to resize w/ screen (EasyTouchCanvas - canvas scaler)
		//   use transform.parent.GetComponent<RectTransform>().localScale
		//   to adjust scaled points back onto the texture coords
		// If modifying scale on the Color Palette GO itself, must also take that into account
		Debug.Log("x, y: " + data.position.x + ", " + data.position.y);
		Debug.Log("converted x, y: " + convertedX + ", " + convertedY);
		
		pickedColor = paletteTexture.GetPixel(convertedX, convertedY);
		
		pickedColorImage.color = pickedColor;

		OnColorPicked(pickedColor);
	}

	public void OnPointerUp(PointerEventData data) {
		OnSelectionFinished();
	}

	public void OnPointerDown(PointerEventData data) { OnDrag(data); }
}
