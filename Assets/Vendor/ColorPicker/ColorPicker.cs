using UnityEngine;
using System;
using System.Collections;

public class ColorPicker : MonoBehaviour
{
	public GameObject receiver;
	public Texture2D colorPicker;
	
	public enum Orientations { TopLeft, TopRight, BottomLeft, BottomRight, Center, CenterLeft, CenterRight };
	
	public Orientations orientation;
	public int adjustmentX;
	public int adjustmentY;
	
	private int mouseX = 50;
	private int mouseY = 1;
	
	private float sliderVal = 1.0f;
	private Color color = new Color(1,0,0,1);
	private Color colorTmp;
	
	private Texture2D quadTexture;
	
	void Start()
	{
		quadTexture = new Texture2D(1,1);
	}

	void OnGUI()
	{
		int offsetX = 0;
		int offsetY = 0;
		
		switch(orientation)
		{
			case Orientations.TopLeft:
				offsetX = 0 + adjustmentX;
				offsetY = 0 + adjustmentY;
			
				break;
			case Orientations.TopRight:
				offsetX = Screen.width - 50 - colorPicker.width + adjustmentX;
				offsetY = 0 + adjustmentY;
				
				break;
			case Orientations.BottomRight:
				offsetX = Screen.width - 50 - colorPicker.width + adjustmentX;
				offsetY = Screen.height - 50 - colorPicker.height + adjustmentY;
				
				break;
			case Orientations.BottomLeft:
				offsetX = 0 + adjustmentX;
				offsetY = Screen.height - 50 - colorPicker.height + adjustmentY;
				
				break;
			case Orientations.Center:
				offsetX = Screen.width / 2 - (colorPicker.width + 50) / 2 + adjustmentX;
				offsetY = Screen.height / 2 - (colorPicker.height + 50) / 2 + adjustmentY;
				
				break;
			case Orientations.CenterLeft:
				offsetX = 0 + adjustmentX;
				offsetY = Screen.height / 2 - (colorPicker.height + 50) / 2 + adjustmentY;
				
				break;
			case Orientations.CenterRight:
				offsetX = Screen.width - 50 - colorPicker.width + adjustmentX;
				offsetY = Screen.height / 2 - (colorPicker.height + 50) / 2 + adjustmentY;
				
				break;
		}
		
		bool hasChanged = false;
		
		GUI.BeginGroup(new Rect(offsetX, offsetY, 50 + colorPicker.width, 50 + colorPicker.height));
		
		if (GUI.RepeatButton(new Rect(50, 0, colorPicker.width, colorPicker.height), colorPicker, GUIStyle.none))
		{
			mouseX = (int) Event.current.mousePosition.x;
			mouseY = (int) Event.current.mousePosition.y;
			
			int x = mouseX - 50;
			int y = colorPicker.height - mouseY - 1;
			
			color = colorPicker.GetPixel(x, y);
			
			hasChanged = true;
		}
		
		float sliderValNew = GUI.HorizontalSlider(new Rect(50, 25 + colorPicker.height, colorPicker.width, 20), sliderVal, 0.0f, 1.0f);
		
		if (sliderValNew != sliderVal)
		{
			sliderVal = sliderValNew;
			hasChanged = true;
		}
		
		colorTmp = color;
		colorTmp *= sliderVal;
		colorTmp.a = 1;
		
		DrawQuad(new Rect(0, 0, 25, 25), colorTmp);
		DrawQuad(new Rect(50, 0, colorPicker.width, colorPicker.height), new Color(0,0,0, 1 - sliderVal));
		
		if (mouseX != 0 && mouseY != 0)
		{
			DrawQuad(new Rect(mouseX - 3, mouseY - 3, 7, 7), Color.black);
			DrawQuad(new Rect(mouseX - 1, mouseY - 1, 3, 3), Color.white);
		}
		
		if (receiver && hasChanged)
		{
			receiver.SendMessage("OnColorPickerValueChange", colorTmp);
		}
		
		GUI.EndGroup();
	}
	
	public Color GetColor()
	{
		return colorTmp;
	}
	
	void DrawQuad(Rect position, Color color)
	{
	    quadTexture.SetPixel(0,0,color);
	    quadTexture.Apply();
		GUI.DrawTexture(position, quadTexture);
	}
}