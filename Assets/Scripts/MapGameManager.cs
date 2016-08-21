using UnityEngine;

public class MapGameManager : MonoBehaviour {
	public static MapGameManager instance = null; //Static instance of GameManager which allows it to be accessed by any other script.

	void Awake() {
		SetupSingletion();

		InitGame();
	}

	public void InitGame() {}

	private void SetupSingletion() {
		//Check if instance already exists
		if (instance == null) {
			instance = this;
		}
		else if (instance != this) {
			//  This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);    
		}

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
	}
}