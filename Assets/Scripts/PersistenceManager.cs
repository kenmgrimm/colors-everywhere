using System;
using UnityEngine;

using BestHTTP;

public class PersistenceManager : MonoBehaviour {
	private static string ROUTE = "http://localhost:3000/paintings";

	private Painting painting;

	// Needs auth
	// https://docs.unity3d.com/ScriptReference/WWWForm-headers.html
	void Start () {
		Debug.Log("Starting PM");

		painting = GameObject.Find("Painting").GetComponent<Painting>();

		LoadPaintingData(4);
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
		Uri updateRoute = new Uri(IsNew() ? ROUTE : ROUTE + "/" + painting.Id());

		string paintingJsonStr = painting.ToJsonStr();

		HTTPRequest request = new HTTPRequest(new Uri(ROUTE), HTTPMethods.Post, OnUpdateRequestFinished);

		//  See:  https://github.com/rack/rack/commit/ff0cac57254dd1d4799a673c9393acb016b136c3
		// Had to modify Rack parser to prevent utf-8 encoding error:
		//   ArgumentError (unknown encoding name - "utf-8"):
		//             v = v[1..-2] if v[0] == '"' && v[-1] == '"'
		// ~/.gem/ruby/2.2.2/gems/rack-1.6.4/lib/rack/multipart/parser.rb
		
		request.AddField("painting", paintingJsonStr);

		request.Send();
	}

	private bool IsNew() {
		return painting.Id() < 0;
	}
}
