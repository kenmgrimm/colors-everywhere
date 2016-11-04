using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorPalette : MonoBehaviour, IPointerDownHandler {
	public PointerEventData pointerEvent;
	public Texture2D paletteTexture;
	private Image pickedColor;


	void Awake() {	
		pickedColor = GameObject.Find("Picked Color").GetComponent<Image>();

		Debug.Log(paletteTexture.width);
		Debug.Log(paletteTexture.height);
	}

	void Start() { }

	public void OnPointerDown( PointerEventData data ) {
		pointerEvent = data;

		int convertedX = (int)(data.position.x / 330 * 256);
		int convertedY = (int)((data.position.y - 360) / 270 * 256);

		Debug.Log(convertedX + ", " + convertedY);
		// Need to convert screenpoint to 
		Debug.Log("Pixel Color: " + paletteTexture.GetPixel(convertedX, convertedY));
		pickedColor.color = paletteTexture.GetPixel(convertedX, convertedY);
	}
}
