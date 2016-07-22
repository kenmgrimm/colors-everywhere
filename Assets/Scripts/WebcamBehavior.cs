using System;
using UnityEngine;
using System.Collections.Generic;
 
public class WebcamBehavior : MonoBehaviour {
  public Material cameraMaterial = null;
 
  private WebCamTexture webCamTexture = null;
  private Camera physicalCamera;

  private int currentDevice = 0;

  void Start() {
    if(cameraMaterial == null) {
      UnityEditor.EditorApplication.isPlaying = false;
    }

    physicalCamera = GameObject.Find("Physical Camera").GetComponent<Camera>();
    Application.RequestUserAuthorization(UserAuthorization.WebCam);

    InvokeRepeating("CheckForMobileCamera", 0, 1);
  }

  void Update() {
    if(webCamTexture != null && webCamTexture.didUpdateThisFrame) {
      cameraMaterial.mainTexture = webCamTexture;
      physicalCamera.targetTexture = (RenderTexture)cameraMaterial.mainTexture;   
    }
  }
 
  private void CheckForMobileCamera() {
    Debug.Log(currentDevice);
    Debug.Log(WebCamTexture.devices.Length);
    if(currentDevice != 1 && WebCamTexture.devices.Length > 1) {
      Debug.Log(currentDevice);

      currentDevice = 1;
      WebCamDevice device = WebCamTexture.devices[currentDevice];

      if(webCamTexture != null) {
        if(webCamTexture.isPlaying) {
          webCamTexture.Stop();
        }
        UnityEngine.Object.DestroyImmediate(webCamTexture, true);
      }

      webCamTexture = new WebCamTexture(device.name);
      webCamTexture.Play();

      physicalCamera.targetTexture = (RenderTexture)cameraMaterial.mainTexture;
             
      cameraMaterial.mainTexture = webCamTexture; 
      
      CancelInvoke("CheckForMobileCamera");
    }
  }
}