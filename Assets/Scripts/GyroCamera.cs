using UnityEngine;

public class GyroCamera : MonoBehaviour {
  private float initialYAngle = 0f;
  private float appliedGyroYAngle = 0f;
  private float calibrationYAngle = 0f;

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

  void ApplyGyroRotation() {
    transform.rotation = Input.gyro.attitude;

    #if UNITY_ANDROID
      transform.Rotate( 0f, 0f, 180f, Space.Self ); //Swap "handedness" ofquaternionfromgyro.
      transform.Rotate( 270f, 180f, 180f, Space.World ); //Rotatetomakesenseasacamerapointingoutthebackofyourdevice.
    #else
      transform.Rotate( 0f, 0f, 180f, Space.Self ); //Swap "handedness" ofquaternionfromgyro.
      transform.Rotate( 90f, 180f, 0f, Space.World ); //Rotatetomakesenseasacamerapointingoutthebackofyourdevice.
    #endif

    appliedGyroYAngle = transform.eulerAngles.y; // Save the angle around y axis for use in calibration.
  }

  void ApplyCalibration() {
    transform.Rotate(0f, -calibrationYAngle, 0f, Space.World ); // Rotates y angle back however much it deviated when calibrationYAngle was saved.
  }
}
