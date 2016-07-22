using System;
using UnityEngine;
using System.Collections.Generic;
 
public class WebcamBehavior : MonoBehaviour {
  public Material cameraMaterial = null;
 
  private GameObject videoScreen;
  private WebCamTexture webCamTexture = null;
  private Camera physicalCamera;

  private WebCamDevice currentDevice;

  void Start() {
    videoScreen = GameObject.Find("Video Screen");
    if(SystemInfo.deviceType == DeviceType.Handheld) {
      Debug.Log("Device Type Handheld");
      Vector3 scale = videoScreen.transform.localScale;
      videoScreen.transform.localScale = new Vector3(scale.x, scale.y, -scale.z);
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
    if(!webCamTexture && webCamTexture.didUpdateThisFrame) {
      cameraMaterial.mainTexture = webCamTexture;
      physicalCamera.targetTexture = (RenderTexture)cameraMaterial.mainTexture;   
    }
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

    webCamTexture = new WebCamTexture(device.name);
    webCamTexture.Play();

    physicalCamera.targetTexture = (RenderTexture)cameraMaterial.mainTexture;
            
    cameraMaterial.mainTexture = webCamTexture; 
  }

  private void DestroyOldCamTexture() {
    if(webCamTexture == null) {
      return;
    }
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