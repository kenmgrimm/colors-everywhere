using UnityEngine;
using System.Collections;

public class GyroCamera : MonoBehaviour {
    Quaternion initialRotation;
    Quaternion gyroInitialRotation;
    bool gyroEnabled;
    public float mouseSpeed = 1.0f;


    #if UNITY_EDITOR
      private bool HasGyro() { 
        return UnityEditor.EditorApplication.isRemoteConnected;
      }
    #else
      private bool HasGyro() { return true; }
    #endif


    void Start () {
      Debug.Log("Start");

      Invoke("BeginTracking", 2f);
    }

    void Update() {
      if(HasGyro()) {
        Quaternion offsetRotation = ConvertRotation(Quaternion.Inverse(gyroInitialRotation) * Input.gyro.attitude);
        transform.rotation = initialRotation * offsetRotation;
      }
      else {
        Debug.Log("NO GYRO");
        transform.Rotate(Input.GetAxis("Mouse Y") * mouseSpeed, Input.GetAxis("Mouse X") * mouseSpeed, 0);
      }
    }

    private void BeginTracking() {
        Debug.Log("BeginTracking");
        gyroEnabled = true;
        initialRotation = transform.rotation;
        gyroInitialRotation = Input.gyro.attitude;

        // transform.rotation = initialRotation = gyroInitialRotation;
    }

    private static Quaternion ConvertRotation(Quaternion q) {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}