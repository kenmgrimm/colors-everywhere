using System;
using UnityEngine;

using BestHTTP;

public class MapDataPersistence : MonoBehaviour {
	private static string ROUTE = "http://localhost:3000/map_data";
	// private static string ROUTE = "https://kenmgrimm-graffiti.herokuapp.com/map_data";

	public delegate void LoadHandler(object sender, EventArgs e);
  public event LoadHandler OnLoad;

	private MapData mapData;

	void Awake () {
		Debug.Log("MapDataPersistence: Awake");
		mapData = GetComponent<MapData>();

		LoadMapData(new Vector2(-104.9245f, 39.54656f));
	}

	private void OnLoadRequestFinished(HTTPRequest request, HTTPResponse response) {
		Debug.Log("MapDataPersistence.OnLoadRequestFinished. Text received:");
		Debug.Log(response.DataAsText);

		mapData.Load(LoadJson(response.DataAsText));

		if(OnLoad != null) {
			OnLoad(mapData, null);
		}
	}

	private void LoadMapData(Vector2 location) {
		Debug.Log("LoadMapData(" + location.x + ", " + location.y + ")");
		HTTPRequest request = 
			new HTTPRequest(new Uri(ROUTE + ".json"), OnLoadRequestFinished);
		request.AddField("latitude", location.x.ToString());
		request.AddField("longitude", location.x.ToString());

		request.Send();
	}

	private JSONObject LoadJson(string jsonStr) {
		// ************************************** Hack
		// Properly parsing floats (lat, long) required modification to JSONObject library
		//   https://github.com/mtschoen/JSONObject/issues/14

		JSONObject jsonObj = new JSONObject(jsonStr);

		return jsonObj;
	}
}
