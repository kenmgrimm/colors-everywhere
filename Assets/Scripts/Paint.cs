using UnityEngine;

public class Paint : MonoBehaviour {
	public GameObject pointer;

	private static float FREQUENCY = 0.1f;
	private bool shouldPaint = false;

	void Start() {
		InvokeRepeating("DrawPaint", 0, FREQUENCY);
	}

	void DrawPaint() {
		if(shouldPaint) {
			pointer.GetComponent<Pointer>().Paint();
			shouldPaint = false;
		}
	}

	public void StartPainting() {
		shouldPaint = true;
	}
}