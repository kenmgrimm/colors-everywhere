using System;
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
		Debug.Log("Load Request Finished! Text received: " + response.DataAsText);

		painting.Initialize(response.DataAsText);

		Debug.Log(painting.paintingData.Id());
	}

	public void LoadPaintingData(int paintingId) {
		HTTPRequest request = 
			new HTTPRequest(new Uri(ROUTE + "/" + paintingId + ".json"), OnLoadRequestFinished);
		request.Send();
	}

	private void OnUpdateRequestFinished(HTTPRequest request, HTTPResponse response) {
		Debug.Log("Update Request Finished! Text received: ");
		Debug.Log(response.DataAsText);
	}

	public void SavePainting() {
		if(!painting.Dirty) return;

		Debug.Log("PaintingPersistence: SavePainting(): id: " + painting.Id());
		
		painting.Dirty = false;

		Uri updateRoute = new Uri(IsNew() ? ROUTE : ROUTE + "/" + painting.Id() + ".json");

		string paintingJsonStr = painting.ToJsonStr();

		byte[] compressed = Compress.Zip(paintingJsonStr);

		HTTPRequest request = new HTTPRequest(updateRoute, HTTPMethods.Post, OnUpdateRequestFinished);

		string compressedBase64 = System.Convert.ToBase64String(compressed);

		request.AddField("painting", compressedBase64);

		request.Send();
	}

	private bool IsNew() {
		return painting.Id() < 0;
	}
}
