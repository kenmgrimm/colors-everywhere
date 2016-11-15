using UnityEngine;
  
public class MagneticSensorButton : MonoBehaviour {
  private Vector3 lastCompass;
 
  public float COMPASS_CHANGE_THRESHOLD = 100.0f;
  public Vector3 compass;

  public delegate void ButtonPressedHandler();
	public event ButtonPressedHandler OnButtonPressed;

  private Vector3 Compass() {
    #if UNITY_EDITOR
      return compass;
    #else
      return Input.compass.rawVector;
    #endif
  }

  void Update() {
    Vector3 current = Compass();
    if(LargeChange(lastCompass, current)) {
      Debug.Log("Button Pressed: " + lastCompass + ", " + current);
      if(OnButtonPressed != null) {
        OnButtonPressed();
      }
    }

    lastCompass = current;
  }

  void Awake() {
    Input.compass.enabled = true;

    lastCompass = Compass();
  }
 
  private bool LargeChange(Vector3 prev, Vector3 current) {
    if (Mathf.Abs(prev.x - current.x) > COMPASS_CHANGE_THRESHOLD ||
      Mathf.Abs(prev.y - current.y) > COMPASS_CHANGE_THRESHOLD ||
      Mathf.Abs(prev.z - current.z) > COMPASS_CHANGE_THRESHOLD) {
      return true;
    }

    return false;
  }
}