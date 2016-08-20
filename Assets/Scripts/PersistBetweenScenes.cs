using UnityEngine;

public class PersistBetweenScenes : MonoBehaviour {
	void Awake () {
    GameObject[] persist = GameObject.FindGameObjectsWithTag("Persist Between Scenes");

    foreach(GameObject obj in persist) {
      DontDestroyOnLoad(obj);
    }
	}
}
