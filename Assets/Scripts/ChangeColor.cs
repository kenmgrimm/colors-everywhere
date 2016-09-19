using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour {
	
	public void Start()
	{
		//Adds a listener to the main slider and invokes a method when the value changes.
		GetComponent<Slider>().onValueChanged.AddListener(delegate { OnChange(); });
	}

	void OnChange () {
		int colorInt = (int)GetComponent<Slider>().value;

		string colorHex = colorInt.ToString("X6");
		string rHex = colorHex.Substring(0, 2);
		string gHex = colorHex.Substring(2, 2);
		string bHex = colorHex.Substring(4, 2);
		Debug.Log(colorHex);

		float r = int.Parse(rHex, NumberStyles.HexNumber) / 255f;
		float g = int.Parse(gHex, NumberStyles.HexNumber) / 255f;
		float b = int.Parse(bHex, NumberStyles.HexNumber) / 255f;

		// int r = BitConverter.ToInt16(bytes.Take(2).ToArray(), 0);
		// int g = BitConverter.ToInt16(bytes.Take(2).ToArray(), 0);
		// int b = BitConverter.ToInt16(bytes.Take(2).ToArray(), 0);
		Debug.Log(r + ", " + g + ", " + b);


		Color color = new Color(r, g, b);
		Debug.Log(color);
		GameObject.Find("Brush").GetComponent<PaintBrush>().ChangeColor(color);
	}
}
