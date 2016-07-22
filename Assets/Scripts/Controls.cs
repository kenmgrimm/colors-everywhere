using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
	public GameObject pointer;

	private Rect paintButtonRect = new Rect(35, 770, 500, 200);
	private Rect colorButtonRect = new Rect(220, 620, 165, 108);
	private Rect distanceButtonRect = new Rect(80, 620, 165, 108);

	void OnGUI () {
		if(GUI.Button(paintButtonRect, "Paint")) {
			pointer.GetComponent<Pointer>().Paint();
		}

		if(GUI.Button(colorButtonRect, "Color")) {
			pointer.GetComponent<Pointer>().ChangeColor();
		}

		if(GUI.Button(colorButtonRect, "Distance")) {
			pointer.GetComponent<Pointer>().ChangeDistance();
		}
	}
	
}
