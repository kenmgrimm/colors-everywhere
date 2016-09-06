using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class NewPaintingButton : EventTrigger {
	private LocationMarker locationMarker;

	void Awake() {
		locationMarker = GameObject.Find("Map").GetComponent<LocationMarker>();
	}

	public override void OnPointerClick( PointerEventData data ) {
		float latitude = locationMarker.GPSCoords().x;
		float longitude = locationMarker.GPSCoords().y;
		
		int compassDirection = 90;
		
		PaintingGameManager.instance.CreatePainting(latitude, longitude, compassDirection);

		SceneManager.LoadScene("Graffiti");
	}
}
