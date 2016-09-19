using UnityEngine;

public abstract class Brush : MonoBehaviour {

	public abstract void ChangeColor(Color color);
  
  public abstract void Extend(float distance);
}