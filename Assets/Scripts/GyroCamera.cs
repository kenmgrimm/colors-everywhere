using UnityEngine;
using System.Collections;
 
public class GyroCamera : MonoBehaviour {
    Quaternion initialRotation;
    Quaternion gyroInitialRotation;
    bool gyroEnabled;
    public float mouseSpeed = 1.0f;
 
    void Start () {
        Debug.Log("Start");
        Input.gyro.enabled = true;

        Invoke("BeginTracking", 2f);
    }

    void Update() {
        // if(gyroEnabled){
        // #if !UNITY_EDITOR
            Quaternion offsetRotation = ConvertRotation(Quaternion.Inverse(gyroInitialRotation) * Input.gyro.attitude);
            transform.rotation = initialRotation * offsetRotation;
        // #else
        //     transform.Rotate(Input.GetAxis("Mouse Y") * mouseSpeed, Input.GetAxis("Mouse X") * mouseSpeed, 0);
        // #endif
        // }
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