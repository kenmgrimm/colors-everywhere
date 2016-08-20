using System.Collections.Generic;
using UnityEngine;

public class MapData : MonoBehaviour {
	public List<PaintingSummary> paintingSummaries = new List<PaintingSummary>();

	public void Load(JSONObject jsonObject) {
		Debug.Log("MapData.Load: " + jsonObject);
		Debug.Log(jsonObject.GetField("paintingSummaries").list[0].GetField("latitude"));

		if(!jsonObject.HasField("paintingSummaries")) {
			Debug.Log("Missing paintingSummaries!");
			return;
		}

		foreach(JSONObject summaryJson in jsonObject.GetField("paintingSummaries").list) {
			paintingSummaries.Add(CreatePaintingSummary(summaryJson));
		}
	}

	private PaintingSummary CreatePaintingSummary(JSONObject summaryJson) {
		return new PaintingSummary(
					id: summaryJson.GetField("id").i,
					latitude: summaryJson.GetField("latitude").f,
					longitude: summaryJson.GetField("longitude").f,
					direction_degrees: summaryJson.GetField("direction_degrees").f
				);
	}
}
