using UnityEngine;

public class MagnetButton : MonoBehaviour {
	// private int MAGNET_STRENGTH = 600;
	
	// private bool wasDown = false;
	// private CardboardMagnetSensor sensor;

	public delegate void ClickHandler();
  public event ClickHandler OnButtonClick;

	void Update() {
		// sensor.MagUpdate(Input.acceleration, Input.compass.rawVector);
		// Debug.Log("Click: " + Input.acceleration + ", " + Input.compass.rawVector + ", " + sensor.Clicked());
		// Debug.Log(Input.compass.rawVector.x + ", " + Input.compass.rawVector.y + ", " + Input.compass.rawVector.z);
	}

	void Awake() {
		// sensor = new CardboardMagnetSensor();
		// Debug.Log("Input.compass.rawVector");

		// OnButtonClick += LogClick;

		// Enable Location Services.  Do not leave this unless absolutely necessary
		// Input.location.Start();
		
		Input.compass.enabled = true;
		// CardboardMagnetSensor.SetEnabled(true);

		// InvokeRepeating("CheckButton", 0, 0.1f);
	}

	// private void CheckButton() {
	// 	Debug.Log(Input.compass.rawVector);

	// 	if (CardboardMagnetSensor.CheckIfWasClicked()) {
	// 		Debug.Log("Cardboard trigger was just clicked");

	// 		CardboardMagnetSensor.ResetClick();
	// 	}

		// if(IsDown()) {
		// 	wasDown = true;
		// 	Debug.Log("IsDown: " + Input.compass.rawVector);
		// }
		// else if(wasDown) {
		// 	wasDown = false;
		// 	Debug.Log("WasDown but isn't down: " + Input.compass.rawVector);
		// 	OnButtonClick();
		// }
	// }
}
