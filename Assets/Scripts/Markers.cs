using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Markers : MonoBehaviour {

  private void Awake() {
    MapDataPersistence persist = GameObject.Find("MapData").GetComponent<MapDataPersistence>();
    persist.OnLoad += RenderMarkers;
  }

  public void RenderMarkers(object sender, EventArgs e) {
    Debug.Log("Markers.RenderMarkers: Rendering markers");

    MapData mapData = (MapData)sender;

    List<PaintingSummary> paintingSummaries = mapData.paintingSummaries;

    OnlineMaps api = OnlineMaps.instance;
    foreach (OnlineMapsMarker marker in api.markers){
      marker.OnClick += OnMarkerClick;
    }

    foreach(PaintingSummary painting in paintingSummaries) {
      Debug.Log("Adding marker at: " + painting.latitude + ", " + painting.longitude);
      OnlineMapsMarker dynamicMarker = api.AddMarker(new Vector2((float)painting.latitude, (float)painting.longitude), null, painting.id + "");
      dynamicMarker.OnClick += OnMarkerClick;
    }
  }

  private void OnMarkerClick(OnlineMapsMarkerBase marker) {
    Debug.Log(marker.label);
    
    int paintingId = int.Parse(marker.label);

    PaintingGameManager.instance.LoadPainting(paintingId);
    
    SceneManager.LoadScene("Graffiti");
  }
}
