#pragma strict
// Gyroscope-controlled camera for iPhone  Android revised 2.26.12
// Stereoskopix FOV2GO Copyright (c) 2011 Perry Hoberman
// Perry Hoberman <hoberman@bway.net>
//
// Usage:
// Attach this script to main camera.
// Note: Unity Remote does not currently support gyroscope.
// Use Landscape Left for correct orientation
//
// This script uses three techniques to get the correct orientation out of the gyroscope attitude:
// 1. creates a parent transform (camParent) and rotates it with eulerAngles
// 2. for Android (Samsung Galaxy Nexus) only: remaps gyro.Attitude quaternion values from xyzw to wxyz (quatMap)
// 3. multiplies attitude quaternion by quaternion quatMult
 
// Also creates a grandparent (camGrandparent) which can be rotated to change heading
// This node allows an arbitrary heading to be added to the gyroscope reading
// so that the virtual camera can be facing any direction in the scene, no matter which way the phone is actually facing
// Option for touch input - horizontal swipe controls heading
 
static var gyroBool : boolean;
private var gyro : Gyroscope;
private var quatMult : Quaternion;
private var quatMap : Quaternion;
// camera grandparent node to rotate heading
private var camGrandparent : GameObject;
private var heading : float = 0;
 
// mouse/touch input
public var touchRotatesHeading : boolean = true;
private var screenSize : Vector2;
private var mouseStartPoint: Vector2;
private var headingAtTouchStart : float = 0;
@script AddComponentMenu ("stereoskopix/s3d Gyro Cam")
 
function Awake() {
    // find the current parent of the camera's transform
    var currentParent = transform.parent;
    // instantiate a new transform
    var camParent = new GameObject ("camParent");
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
       
    // check whether device supports gyroscope
    #if UNITY_3_4
    gyroBool = Input.isGyroAvailable;
    #endif
    #if UNITY_3_5
    gyroBool = SystemInfo.supportsGyroscope;
    #endif
   
    if (gyroBool) {
        gyro = Input.gyro;
        gyro.enabled = true;
        #if UNITY_IPHONE
            camParent.transform.eulerAngles = Vector3(90,90,0);
            if (Screen.orientation == ScreenOrientation.LandscapeLeft) {
                quatMult = Quaternion(0,0,0.7071,0.7071);
            } else if (Screen.orientation == ScreenOrientation.LandscapeRight) {
                quatMult = Quaternion(0,0,-0.7071,0.7071);
            } else if (Screen.orientation == ScreenOrientation.Portrait) {
                quatMult = Quaternion(0,0,1,0);
            } else if (Screen.orientation == ScreenOrientation.PortraitUpsideDown) {
                quatMult = Quaternion(0,0,0,1);
            }
        #endif
        #if UNITY_ANDROID
            camParent.transform.eulerAngles = Vector3(-90,0,0);
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
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    } else {
        #if UNITY_EDITOR
            //print("NO GYRO");
        #endif
    }
}
 
function Start() {
    screenSize.x = Screen.width;
    screenSize.y = Screen.height;
}
 
function Update () {
    if (gyroBool) {
        #if UNITY_IPHONE
            quatMap = gyro.attitude;
        #endif
        #if UNITY_ANDROID
            quatMap = Quaternion(gyro.attitude.w,gyro.attitude.x,gyro.attitude.y,gyro.attitude.z);
        #endif
        transform.localRotation = quatMap * quatMult;
    }
    #if (UNITY_IPHONE || UNITY_ANDROID)  !UNITY_EDITOR
        if (touchRotatesHeading) {
            GetTouchMouseInput();
        }
        camGrandparent.transform.localEulerAngles.y = heading;
    #endif
}
 
function GetTouchMouseInput() {
    if(Input.GetMouseButtonDown(0)) {
        mouseStartPoint = Input.mousePosition;
        headingAtTouchStart = heading;
    } else if (Input.GetMouseButton(0)) {
        var delta : Vector2;
        var mousePos = Input.mousePosition;
        delta.x = (mousePos.x - mouseStartPoint.x)/screenSize.x;
        delta.y = (mousePos.y - mouseStartPoint.y)/screenSize.y;
        heading = (headingAtTouchStart+delta.x*100);
        heading = heading%360;
    }
}