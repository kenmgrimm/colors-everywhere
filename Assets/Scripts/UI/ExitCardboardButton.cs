using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ExitCardboardButton : EventTrigger {
	public override void OnPointerClick( PointerEventData data ) {
		SceneManager.LoadScene("Painting");
	}
}
