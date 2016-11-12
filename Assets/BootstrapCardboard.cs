using UnityEngine;

public class BootstrapCardboard : MonoBehaviour {
	void Awake () {
		if(GameObject.Find("Painting(Clone)")) {
			GameObject.Find("Environment - Dev only").SetActive(false);
		}
	}
}
