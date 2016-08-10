
using UnityEngine;
using System.Collections;

public class PersistenceManager : MonoBehaviour {
	private Painting painting;

	// Needs auth
	// https://docs.unity3d.com/ScriptReference/WWWForm-headers.html
	void Start () {
		Debug.Log("Starting PM");

		painting = GameObject.Find("Painting").GetComponent<Painting>();
		
		Invoke("CreatePainting", 5);
	}

	private void CreatePainting() {
		Hashtable postHeader = new Hashtable();
		
		string paintingJsonStr = painting.ToJsonStr();
		
		// string jsonString = "{\"painting\":{\"latitude\":1.2345,\"longitude\":1.2345,\"direction_degrees\":12,\"strokes_attributes\":[{\"brush_type\":3,\"color\":\"80ff3ed9\",\"points_attributes\":[{\"position_x\":0.01,\"position_y\":0.02,\"position_z\":0.03},{\"position_x\":0.11,\"position_y\":0.12,\"position_z\":0.13},{\"position_x\":0.21,\"position_y\":0.22,\"position_z\":0.23}]}]}}";
		// string jsonString = "{\"latitude\":1.2345,\"longitude\":1.2345,\"direction_degrees\":15,\"strokes_attributes\":[{\"brush_type\":3,\"color\":\"80ff3ed9\",\"points_attributes\":[{\"position_x\":0.01,\"position_y\":0.02,\"position_z\":0.03},{\"position_x\":0.11,\"position_y\":0.12,\"position_z\":0.13},{\"position_x\":0.21,\"position_y\":0.22,\"position_z\":0.23}]}]}";

		postHeader.Add("Content-Type", "text/json");
		// postHeader.Add("Content-Length", jsonString.Length + "");
		WWWForm form = new WWWForm();

		form.AddField("painting", paintingJsonStr);

		Debug.Log("Strokes: ");
		Debug.Log(painting.paintingData.strokes.Count);
		Debug.Log(painting.paintingData.strokes[0]);

		Debug.Log("Posting: " + paintingJsonStr);
		WWW request = new WWW("http://localhost:3000/paintings.json", form);
	}
}
