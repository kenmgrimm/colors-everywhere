using UnityEngine;
using UnityEngine.EventSystems;

public class ColorWheel : EventTrigger {
	private GameObject brush;
	private SpriteRenderer spriteRenderer;
	private Vector3 viewportCorner;
	private GUITexture gui;
	Color[] pickerPixels;
	private int Width { get { return spriteRenderer.sprite.texture.width; } }
	private int Height { get { return spriteRenderer.sprite.texture.height; } }

	private Color pickedColor;

	void Awake () {
		brush = GameObject.Find("Brush");

		spriteRenderer = GetComponent<SpriteRenderer>();
		pickerPixels = spriteRenderer.sprite.texture.GetPixels();

		// Vector3 position = Camera.main.ViewportToScreenPoint(transform.position);
		// viewportCorner = new Vector3(position.x + gui.pixelInset.x, position.y + gui.pixelInset.y, 0.0f);
	}
	
	public override void OnPointerClick( PointerEventData data ) {
		Vector3 screenPos = Camera.main.ScreenToWorldPoint(data.position);  

		Debug.Log(screenPos);
		// Debug.Log(pickerPixels[screenPos.y ])
	}

	void Update () {
		// if (Input.GetMouseButton (0)) {
		// 	Vector3 screenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);    
		// 	screenPos = new Vector2(screenPos.x, screenPos.y);

		// 	//check if we clicked this picker control
		// 	RaycastHit2D[] ray = Physics2D.RaycastAll(screenPos, Vector2.zero, 0.01f);

		// 	for (int i = 0; i < ray.Length; i++) {
		// 		if (ray[i].collider == Collider) {
		// 			//get color data
		// 			screenPos -= ColorPicker.transform.position;
		// 			int x = (int)(screenPos.x * Width);
		// 			int y = (int)(screenPos.y * Height) + Height;

		// 			if (x > 0 && x < Width && y > 0 && y < Height) {
		// 				pickedColor = pickerPixels[y * Width + x];
		// 			}                   
		// 			break;
		// 		}
		// 	}
		// }
	}

	public void TogglePalette() {
		gameObject.SetActive(!gameObject.activeSelf);
	}

	// public override void OnPointerClick( PointerEventData data ) {
	// 	// Vector2 screenPosition = data.pointerCurrentRaycast.screenPosition;

	// 	var v3Pixel = Input.mousePosition - viewportCorner;
	// 	Debug.Log(wheelTexture.GetPixel(v3Pixel.x, v3Pixel.y));
		
	// 	string color  = "AAAAAA";
	// 	brush.GetComponent<BrushPointer>().ChangeColor(color);

	// 	gameObject.SetActive(false);
	// }

}
