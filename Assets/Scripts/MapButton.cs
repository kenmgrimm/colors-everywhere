using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MapButton : EventTrigger {
	void Start () {
		Debug.Log("******************Start");
	}

	public override void OnPointerClick( PointerEventData data ) {
		SceneManager.LoadScene("Map");
	}
}
