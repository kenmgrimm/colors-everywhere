using System;
using UnityEngine;
using System.Collections.Generic;
 
// This should probably eventually be replaced with NatCam or similar ($75)
// Or re-implement using: 
//  http://answers.unity3d.com/questions/773464/webcamtexture-correct-resolution-and-ratio.html
public class WebcamBehavior : MonoBehaviour {
  public Material cameraMaterial = null;
 
  private GameObject videoScreen;
  private WebCamTexture webCamTexture = null;
  private Camera physicalCamera;

  private int deviceWidth = 2000;  // (or Screen.width) but I think it clamps it
  private int deviceHeight = 2000;  // (or Screen.height) but I think it clamps it

  private WebCamDevice currentDevice;

  void Start() {
    videoScreen = GameObject.Find("Video Screen");
    if(SystemInfo.deviceType == DeviceType.Handheld) {
      Debug.Log("Device Type Handheld");

      // When on mobile we were flipping scale but may not be necessary
      // Vector3 scale = videoScreen.transform.localScale;
      // videoScreen.transform.localScale = new Vector3(scale.x, scale.y, -scale.z);
    }

    #if UNITY_EDITOR
      if(!cameraMaterial) {
        UnityEditor.EditorApplication.isPlaying = false;
      }
    #endif
    
    physicalCamera = GameObject.Find("Physical Camera").GetComponent<Camera>();

    Application.RequestUserAuthorization(UserAuthorization.WebCam);

    InvokeRepeating("CheckForMobileCamera", 0, 1);
  }

  void Update() {
    // Skip making adjustment for incorrect camera data  (width < 100)
    // if(webCamTexture.width < 100) {
    //   return;
    // }
  }
 
  private void CheckForMobileCamera() {
    Debug.Log("Checking Mobile");
    if(HasCamera()) {
      WebCamDevice newDevice = default(WebCamDevice);

      if(RearCamera().name != default(WebCamDevice).name) {
        Debug.Log("RearCamera");
        newDevice = RearCamera();
      }
      else if(!WebCam().Equals(default(WebCamDevice))) {
        Debug.Log("WebCam");
        newDevice = WebCam();
      }

      if(newDevice.name == currentDevice.name) {
        return;
      }
      currentDevice = newDevice;

      SetNewCamTexture(currentDevice);
    }

    if(currentDevice.name != "FaceTime HD Camera" && !currentDevice.isFrontFacing) {
      Debug.Log("Mobile camera found");
      Debug.Log(currentDevice.name);
      CancelInvoke("CheckForMobileCamera");
    }
  }

  private void SetNewCamTexture(WebCamDevice device) {
    DestroyOldCamTexture();

    webCamTexture = new WebCamTexture(device.name, deviceWidth, deviceHeight, 60);
    webCamTexture.filterMode = FilterMode.Trilinear;
    webCamTexture.Play();

    physicalCamera.targetTexture = (RenderTexture)cameraMaterial.mainTexture;
            
    cameraMaterial.mainTexture = webCamTexture; 
  }

  private void DestroyOldCamTexture() {
    if(webCamTexture == null) { return; }
    
    if(webCamTexture.isPlaying) {
      webCamTexture.Stop();
    }
    UnityEngine.Object.DestroyImmediate(webCamTexture, true);
  }

  private bool HasCamera() {
    return RearCamera().name != default(WebCamDevice).name || WebCam().name != default(WebCamDevice).name;
  }

  private WebCamDevice RearCamera() {
    WebCamDevice[] devices = WebCamTexture.devices;

    foreach (WebCamDevice device in devices){
      if(device.name != "FaceTime HD Camera" && !device.isFrontFacing) {
        return device;
      }
    }

    return default(WebCamDevice);
  }

  private WebCamDevice WebCam() {
    #if !UNITY_EDITOR
      return default(WebCamDevice);
    #endif

    foreach(WebCamDevice device in WebCamTexture.devices) {
      if(device.name == "FaceTime HD Camera" || !device.isFrontFacing) {
        return device;
      }
    }

    return default(WebCamDevice);
  }
}