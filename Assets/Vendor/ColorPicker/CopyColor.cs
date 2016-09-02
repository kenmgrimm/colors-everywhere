using UnityEngine;
using System.Collections;

public class CopyColor : MonoBehaviour
{
	public ColorPicker colorPicker;
			
	void Update()
	{
		// Get the color directly. ColorListener is preferred over this.
		
		GetComponent<Renderer>().material.color = colorPicker.GetColor();
	}
}
