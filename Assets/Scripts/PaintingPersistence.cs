using System;
using System.Collections.Generic;
using UnityEngine;

using BestHTTP;

public class PaintingPersistence : MonoBehaviour {
	// private static string ROUTE = "http://localhost:3000/paintings";
	private static string ROUTE = "https://kenmgrimm-graffiti.herokuapp.com/paintings";

	// bad design
	private Painting painting;

	void Awake () {
		Debug.Log("PaintingPersistence Awake");

		painting = GetComponent<Painting>();
	}

	private void OnLoadRequestFinished(HTTPRequest request, HTTPResponse response) {
		if (request.Exception != null) {
			Util.LogException(request.Exception);
			return;
		}

		Debug.Log("Load Request Finished! Text received. Size(Uncompressed): " + response.Data.Length +
		  "\nBody Text: " + response.DataAsText);

		// foreach(KeyValuePair<string, List<string>> entry in response.Headers) {
		// 	Debug.Log(entry.Key + ": " + entry.Value[0]);
		// }

		painting.Initialize(response.DataAsText);

		Debug.Log(painting.PaintingData().Id());
	}

	public void LoadPaintingData(int paintingId) {
		HTTPRequest request = 
			new HTTPRequest(new Uri(ROUTE + "/" + paintingId + ".json"), OnLoadRequestFinished);
		request.Send();
	}

	private void OnUpdateRequestFinished(HTTPRequest request, HTTPResponse response) {
		if (request.Exception != null) {
			Util.LogException(request.Exception);
			return;
		}
		Debug.Log("Update Painting POST Complete. Status: " + response.StatusCode);
	}

	public void SavePainting() {
		if(!painting.Dirty) return;

		Debug.Log("PaintingPersistence: SavePainting(): id: " + painting.Id());
		
		painting.Dirty = false;

		Uri updateRoute = new Uri(IsNew() ? ROUTE : ROUTE + "/" + painting.Id() + ".json");

		HTTPRequest request = new HTTPRequest(updateRoute, HTTPMethods.Post, OnUpdateRequestFinished);

		string data = CompressedPaintingData();
		Debug.Log("POSTing data, size(compressed): " + data.Length);
		
		request.AddField("painting", data);

		request.Send();
	}

	private bool IsNew() {
		return painting.Id() < 0;
	}

	private string CompressedPaintingData() {
		string paintingJsonStr = painting.ToJsonStr();

		byte[] compressed = Compress.Zip(paintingJsonStr);

		return System.Convert.ToBase64String(compressed);
	}
}
