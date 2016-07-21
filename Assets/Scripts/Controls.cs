using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
	public GameObject pointer;

	void OnGUI () {
		if(GUI.Button(new Rect(20,40,80,20), "Paint")) {
			pointer.GetComponent<Pointer>().Paint();
		}

		if(GUI.Button(new Rect(20,60,80,20), "Color")) {
			pointer.GetComponent<Pointer>().ChangeColor();
		}
	}
	
}
