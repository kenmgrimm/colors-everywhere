using UnityEngine;

public class PaintingGameManager : MonoBehaviour {
	public static PaintingGameManager instance = null;

	private GameObject paintingPrefab;

	private void LoadInitialPrefabs() {
		paintingPrefab = Util.LoadPrefab("Painting");

		Util.LoadAndCreatePrefab("Environment");
	}

	void Awake() {
		GameObject.Find("Environment - Dev only").SetActive(false);

		if(!Painting()) {
			SetupSingletion();

			LoadInitialPrefabs();

			// FIX THIS In dev mode we may start in painting scene and need to create one on the fly
			// InstantiatePainting();

			// Let's always load an existing painting
			PaintingGameManager.instance.LoadPainting(8);
			// PaintingGameManager.instance.CreatePainting(1, 1, 1);


			// Painting().paintingData.id = 8;
		}
	}

	public Painting Painting() {
		GameObject paintingObj = GameObject.FindWithTag("Painting");
		if(!paintingObj) {
			return null;
		} 
		
		return paintingObj.GetComponent<Painting>();
	}

	public void CreatePainting(float latitude, float longitude, int directionDegrees) {
		Painting painting = InstantiatePainting();

		painting.Initialize(latitude, longitude, directionDegrees);
	}

	public void LoadPainting(int paintingId) {
		Painting painting = InstantiatePainting();
		painting.Load(paintingId);
	}

	private Painting InstantiatePainting() {
		if(Painting()) {
			Destroy(Painting().gameObject);
		}

		Painting painting = Instantiate(paintingPrefab).GetComponent<Painting>();
		
		DontDestroyOnLoad(painting);

		return painting;
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

		DontDestroyOnLoad(gameObject);
	}
}
