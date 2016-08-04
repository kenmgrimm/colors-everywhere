using UnityEngine;
using UnityEngine.SceneManagement;

public class Markers : MonoBehaviour {
  public Vector2[] markers = new Vector2[3];

  private void Start() {
    OnlineMaps api = OnlineMaps.instance;

    foreach (OnlineMapsMarker marker in api.markers){
      marker.OnClick += OnMarkerClick;
    }

    foreach(Vector2 marker in markers) {
      OnlineMapsMarker dynamicMarker = api.AddMarker(new Vector2(marker.x, marker.y), null, "Dynamic marker");
      dynamicMarker.OnClick += OnMarkerClick;
    }
  }

  private void OnMarkerClick(OnlineMapsMarkerBase marker) {
    Debug.Log(marker.label);
    
    SceneManager.LoadScene("Graffiti");
  }
}
