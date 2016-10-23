using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CardboardButton : EventTrigger {
	public override void OnPointerClick( PointerEventData data ) {
		SceneManager.LoadScene("Cardboard");
	}
}
