using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
	public GameObject pointer;

	public Rect paintButtonRect = new Rect(35, 770, 500, 200);
	public Rect colorButtonRect = new Rect(80, 520, 165, 108);
	public Rect distanceButtonRect = new Rect(80, 620, 165, 108);

	void OnGUI () {
		// if(GUI.Button(paintButtonRect, "Paint")) {
		// 	pointer.GetComponent<Pointer>().Paint();
		// }

		if(GUI.Button(colorButtonRect, "Color")) {
			pointer.GetComponent<Pointer>().ChangeColor();
		}

		if(GUI.Button(distanceButtonRect, "Distance")) {
			pointer.GetComponent<Pointer>().ChangeDistance();
		}
	}
	
}
