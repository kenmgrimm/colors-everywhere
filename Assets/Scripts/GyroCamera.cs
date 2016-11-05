using UnityEngine;

public class GyroCamera : MonoBehaviour {
  private static float JOYSTICK_ROTATION_MULTIPLIER = 5.0f;
  private static float JOYSTICK_MOVE_MULTIPLIER = 0.4f;

  private float initialYAngle = 0f;
  private float appliedGyroYAngle = 0f;
  private float calibrationYAngle = 0f;

  private float joystickYRotation = 0f; 

  void Start() {
    Input.gyro.enabled = true;
    Application.targetFrameRate = 60;
    initialYAngle = transform.eulerAngles.y;
  }

  void Update() {
    ApplyGyroRotation();
    // ApplyCalibration();
  }

  // void OnGUI()
  // {
  //     if( GUILayout.Button( "Calibrate", GUILayout.Width( 300 ), GUILayout.Height( 100 ) ) )
  //     {
  //         CalibrateYAngle();
  //     }
  // }

  public void CalibrateYAngle() {
    calibrationYAngle = appliedGyroYAngle - initialYAngle; // Offsets the y angle in case it wasn't 0 at edit time.
  }

	public void MoveSpeed(Vector2 move){
    // Debug.Log("MoveSpeed");
    // Debug.Log(move);

    joystickYRotation += move.x * JOYSTICK_ROTATION_MULTIPLIER;
		
    Vector3 velocity = transform.forward * move.y * JOYSTICK_MOVE_MULTIPLIER;

		transform.position += new Vector3(velocity.x, 0, velocity.z);
	}

  void ApplyGyroRotation() {
    transform.rotation = Input.gyro.attitude;

    #if UNITY_ANDROID
      transform.Rotate( 0f, 0f, 180f, Space.Self ); //Swap "handedness" ofquaternionfromgyro.
      transform.Rotate( 270f, 180f, 180f, Space.World ); //Rotatetomakesenseasacamerapointingoutthebackofyourdevice.
    #else
      transform.Rotate( 0f, 0f, 180f, Space.Self ); //Swap "handedness" ofquaternionfromgyro.
      transform.Rotate( 90f, 180f, 0f, Space.World ); //Rotatetomakesenseasacamerapointingoutthebackofyourdevice.
    #endif
    
    transform.Rotate(new Vector3(0, joystickYRotation, 0), Space.World);

    appliedGyroYAngle = transform.eulerAngles.y; // Save the angle around y axis for use in calibration.
  }

  void ApplyCalibration() {
    transform.Rotate(0f, -calibrationYAngle, 0f, Space.World ); // Rotates y angle back however much it deviated when calibrationYAngle was saved.
  }
}
