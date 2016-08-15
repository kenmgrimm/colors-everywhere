using System;
using UnityEngine;
using System.Collections;

using BestHTTP;
// using JsonData;

public class PersistenceManager : MonoBehaviour {
	private static string ROUTE = "http://localhost:3000/paintings";

	private Painting painting;

	// Needs auth
	// https://docs.unity3d.com/ScriptReference/WWWForm-headers.html
	void Start () {
		Debug.Log("Starting PM");

		painting = GameObject.Find("Painting").GetComponent<Painting>();

		LoadPaintingData(4);

		// Invoke("CreatePainting", 3);

		Invoke("UpdatePainting", 5);
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

		painting.Load(response.DataAsText);
	}

	private void SavePainting(bool isNew) {
		string updateRoute = isNew ? ROUTE : ROUTE + "/" + painting.Id();
		
		Hashtable postHeader = new Hashtable();
		
		string paintingJsonStr = painting.ToJsonStr();

		postHeader.Add("Content-Type", "text/json");
		WWWForm form = new WWWForm();
		form.AddField("painting", paintingJsonStr);
Debug.Log("SavePainting");
Debug.Log(updateRoute);
Debug.Log(paintingJsonStr);
		WWW request = new WWW(updateRoute, form);
	}

	private void UpdatePainting() {
		SavePainting(isNew: false);
	}

	private void CreatePainting() {
		SavePainting(isNew: true);
	}
}
