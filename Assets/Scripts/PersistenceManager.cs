using System;
using UnityEngine;

using BestHTTP;

public class PersistenceManager : MonoBehaviour {
	// private static string ROUTE = "http://localhost:3000/paintings";
	private static string ROUTE = "https://kenmgrimm-graffiti.herokuapp.com/paintings";

	private Painting painting;

	// Needs auth
	// https://docs.unity3d.com/ScriptReference/WWWForm-headers.html
	void Start () {
		Debug.Log("Starting PM");

		painting = GameObject.Find("Painting").GetComponent<Painting>();

		LoadPaintingData(1);
	}

	public void OnDestroy() {
		if(painting.Dirty) {
			SavePainting();
		}
	}

	private void OnLoadRequestFinished(HTTPRequest request, HTTPResponse response) {
		Debug.Log("Load Request Finished! Text received: " + response.DataAsText);

		painting.Load(response.DataAsText);
		Debug.Log(painting.paintingData);
		Debug.Log(painting.paintingData.Id());
	}

	private void LoadPaintingData(int paintingId) {
		HTTPRequest request = 
			new HTTPRequest(new Uri(ROUTE + "/" + paintingId + ".json"), OnLoadRequestFinished);
		request.Send();
	}

	private void OnUpdateRequestFinished(HTTPRequest request, HTTPResponse response) {
		Debug.Log("Update Request Finished! Text received: ");
		Debug.Log(response.DataAsText);
	}

	private void SavePainting() {
Debug.Log(painting.Id());
Debug.Log(painting.paintingData.Id());
		Uri updateRoute = new Uri(IsNew() ? ROUTE : ROUTE + "/" + painting.Id());

		string paintingJsonStr = painting.ToJsonStr();

		HTTPRequest request = new HTTPRequest(updateRoute, HTTPMethods.Post, OnUpdateRequestFinished);
		request.AddField("painting", paintingJsonStr);

		request.Send();
	}

	private bool IsNew() {
		return painting.Id() < 0;
	}
}
