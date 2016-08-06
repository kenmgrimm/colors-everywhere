using UnityEngine;

public class Paint : MonoBehaviour {
	public GameObject pointer;

	// private static float FREQUENCY = 0.05f;
	private bool shouldPaint = false;

	// void Start() {
	// 	InvokeRepeating("DrawPaint", 0, FREQUENCY);
	// }

	void Update() {
		DrawPaint();
	}
	
	void DrawPaint() {
		if(shouldPaint) {
			pointer.GetComponent<Pointer>().Paint();
		}
	}

	public void StartPainting() {
		shouldPaint = true;
	}

	public void StopPainting() {
		shouldPaint = false;
	}
}