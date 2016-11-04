using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MapButton : EventTrigger {
	public override void OnPointerClick( PointerEventData data ) {
		SceneManager.LoadScene("Map");
	}
}
