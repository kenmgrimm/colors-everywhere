using UnityEngine;

public class Paint : MonoBehaviour {
	public GameObject pointer;

	private float frequency = 0.1f;
	private bool shouldPaint = false;

	void Start() {
		InvokeRepeating("DrawPaint", 0, 0.1f);
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