using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ExitCardboardButton : MonoBehaviour, IPointerClickHandler {
	public void OnPointerClick( PointerEventData data ) {
		SceneManager.LoadScene("Painting");
	}
}
