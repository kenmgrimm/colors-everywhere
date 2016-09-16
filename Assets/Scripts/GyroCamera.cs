using UnityEngine;

public class GyroCamera : MonoBehaviour {
  Quaternion initialRotation;
  Quaternion gyroInitialRotation;
  // Quaternion lastRotation;
  Quaternion lastGyroRotation;

  private bool gyroInitialized = false;
  public float mouseSpeed = 1.0f;

  private GameObject camParent;
  private GameObject camGrandparent;
  private Quaternion quatMap;
  private Quaternion quatMult;

  #if UNITY_EDITOR
    private bool HasGyro() { 
      return UnityEditor.EditorApplication.isRemoteConnected;
    }
  #else
    private bool HasGyro() { return true; }
  #endif


  void Awake () {
    Transform currentParent = transform.parent;
    // instantiate a new transform
    camParent = new GameObject ("camParent");
    // match the transform to the camera position
    camParent.transform.position = transform.position;
    // make the new transform the parent of the camera transform
    transform.parent = camParent.transform;
    // instantiate a new transform
    camGrandparent = new GameObject ("camGrandParent");
    // match the transform to the camera position
    camGrandparent.transform.position = transform.position;
    // make the new transform the grandparent of the camera transform
    camParent.transform.parent = camGrandparent.transform;
    // make the original parent the great grandparent of the camera transform
    camGrandparent.transform.parent = currentParent;
    
    Input.gyro.enabled = true;
    
    InvokeRepeating("InitializeGyro", 0, 1);
  }

  void InitializeGyro() {
    if(HasGyro()) {
      #if UNITY_IPHONE
        // camParent.transform.eulerAngles = new Vector3(90,90,0);

        if (Screen.orientation == ScreenOrientation.LandscapeLeft) {
            quatMult = new Quaternion(0,0,0.7071f,0.7071f);
        } else if (Screen.orientation == ScreenOrientation.LandscapeRight) {
            quatMult = new Quaternion(0,0,-0.7071f,0.7071f);
        } else if (Screen.orientation == ScreenOrientation.Portrait) {
            quatMult = new Quaternion(0,0,1,0);
        } else if (Screen.orientation == ScreenOrientation.PortraitUpsideDown) {
            quatMult = new Quaternion(0,0,0,1);
        }
    #endif
    #if UNITY_ANDROID
        // camParent.transform.eulerAngles = Vector3(-90,0,0);

        if (Screen.orientation == ScreenOrientation.LandscapeLeft) {
            quatMult = Quaternion(0,0,0.7071,-0.7071);
        } else if (Screen.orientation == ScreenOrientation.LandscapeRight) {
            quatMult = Quaternion(0,0,-0.7071,-0.7071);
        } else if (Screen.orientation == ScreenOrientation.Portrait) {
            quatMult = Quaternion(0,0,0,1);
        } else if (Screen.orientation == ScreenOrientation.PortraitUpsideDown) {
            quatMult = Quaternion(0,0,1,0);
        }
    #endif

    Debug.Log("Initial rot");
    Debug.Log(Input.gyro.attitude.eulerAngles);
    Debug.Log(camParent.transform.rotation.eulerAngles);
    
    camParent.transform.rotation = 
      Quaternion.Euler(Input.gyro.attitude.eulerAngles + new Vector3(90, 0, 0));
    
    // camGrandparent.transform.Rotate(90, 0, 0);

Debug.Log(camParent.transform.rotation.eulerAngles);
      // Debug.Log("Setting initial rotation");
      // Debug.Log(Input.gyro.attitude);
      // gyroInitialRotation = Input.gyro.attitude;
      // // initialRotation = transform.rotation;
      // transform.rotation = gyroInitialRotation;
      // lastGyroRotation = gyroInitialRotation;
      // // lastRotation = initialRotation;

      gyroInitialized = true;
      CancelInvoke("InitializeGyro");
    }
  }

  void Update() {
    if(HasGyro() && gyroInitialized) {
        #if UNITY_IPHONE
            quatMap = Input.gyro.attitude;
        #endif
        #if UNITY_ANDROID
            quatMap = Quaternion(gyro.attitude.w,gyro.attitude.x,gyro.attitude.y,gyro.attitude.z);
        #endif
        transform.localRotation = quatMap * quatMult;

      // Quaternion offsetRotation = ConvertRotation(Quaternion.Inverse(lastGyroRotation) * Input.gyro.attitude);
      // transform.rotation = transform.rotation * offsetRotation;

      // lastGyroRotation = Input.gyro.attitude;
    }
    else {
      transform.Rotate(Input.GetAxis("Mouse Y") * mouseSpeed, Input.GetAxis("Mouse X") * mouseSpeed, 0);
    }
  }

  private static Quaternion ConvertRotation(Quaternion q) {
    return new Quaternion(q.x, q.y, -q.z, -q.w);
  }
}