using UnityEngine;
using System.Collections;

public class GyroCamera : MonoBehaviour {
  Quaternion initialRotation;
  Quaternion gyroInitialRotation;
  // Quaternion lastRotation;
  Quaternion lastGyroRotation;

  private bool gyroInitialized = false;
  public float mouseSpeed = 1.0f;

  #if UNITY_EDITOR
    private bool HasGyro() { 
      return UnityEditor.EditorApplication.isRemoteConnected;
    }
  #else
    private bool HasGyro() { return true; }
  #endif


  void Start () {
    Input.gyro.enabled = true;

    InvokeRepeating("InitializeGyro", 0, 1);
  }

  void InitializeGyro() {
    if(HasGyro()) {
      gyroInitialRotation = Input.gyro.attitude;
      initialRotation = transform.rotation;

      lastGyroRotation = gyroInitialRotation;
      // lastRotation = initialRotation;

      gyroInitialized = true;
      CancelInvoke("InitializeGyro");
    }
  }

  void Update() {
    if(HasGyro() && gyroInitialized) {
      Quaternion offsetRotation = ConvertRotation(Quaternion.Inverse(lastGyroRotation) * Input.gyro.attitude);
      transform.rotation = transform.rotation * offsetRotation;

      lastGyroRotation = Input.gyro.attitude;
      // lastRotation = transform.rotation;
    }
    else {
      transform.Rotate(Input.GetAxis("Mouse Y") * mouseSpeed, Input.GetAxis("Mouse X") * mouseSpeed, 0);
    }
  }

  private static Quaternion ConvertRotation(Quaternion q) {
    return new Quaternion(q.x, q.y, -q.z, -q.w);
  }
}