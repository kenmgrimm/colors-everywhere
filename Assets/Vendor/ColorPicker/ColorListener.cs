using UnityEngine;
using System.Collections;

public class ColorListener : MonoBehaviour
{
	// Get color when value has changed
	
	void OnColorPickerValueChange(Color color)
	{
		GetComponent<Renderer>().material.color = color;
	}
}
