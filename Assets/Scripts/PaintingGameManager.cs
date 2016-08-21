using UnityEngine;

public class PaintingGameManager : MonoBehaviour {
	public static PaintingGameManager instance = null; //Static instance of GameManager which allows it to be accessed by any other script.

	private Painting painting;

	void Awake() {
		SetupSingletion();

		InitGame();
	}

	public void InitGame() {
		painting = GameObject.Find("Painting").GetComponent<Painting>();
	}

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

	public Painting Painting() {
		return painting;
	}
}
