using UnityEngine;
using UnityEngine.UI;

public class ModelBrush : Brush {
	private static float MIN_EXTENSION = 0.01f;  // I think should be >= near clipping plane 
	private static float EXTENSION_FACTOR = 0.5f;
	
	private static float SCALE_UP_FACTOR = 1.5f;
	private static float SCALE_DOWN_FACTOR = 1.0f / SCALE_UP_FACTOR;
	private static float MAX_SCALE = 20f;
	private static float MIN_SCALE = 0.2f;

	private float pointerLength;

	private Camera paintingCamera;

	private Model modelBrush;

	private Painting painting;

	private int brushNum = 0;
	private float scale = 1.0f;


	void Awake() {
		paintingCamera = GameObject.Find("Painting Camera").GetComponent<Camera>();

		// Should not be created here, should exist and be looked up after selection on the brush palette
		LoadNewBrushModel(ModelType.Default());

		// Need to set starting pointerLength using extension slider.  Refactor and de-couple some of this stuff
		// DE-COUPLE
		float sliderValue = GameObject.Find("Extension Slider").GetComponent<Slider>().value;
		
		Extend(sliderValue);
	}

	public void LoadNewBrushModel(ModelType modelType) {
Debug.Log("LoadNewBrushModel: " + modelType.Name());
		if(modelBrush) {
			// if the model was not used in the scene (painted), destroy it
			Destroy(modelBrush.gameObject);
		}
		modelBrush = Model.CreateInstance(modelType, LocationOnGround(), Quaternion.identity, Vector3.one * scale, Color.blue, transform).GetComponent<Model>();		
	}

	public override void Extend(float distance) {
		float newLength = distance * EXTENSION_FACTOR;
		pointerLength = newLength > MIN_EXTENSION ? newLength : MIN_EXTENSION;
	}

	private Vector3 Location() {
		Ray ray = paintingCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

		return ray.origin + ray.direction * pointerLength;
	}

	private Vector3 LocationOnGround() {
		Vector3 groundLocation = Location();
		groundLocation.y = 0;

		return groundLocation;
	}

	// Probably should be optimized
	void Update() {
		// Necesary because painting is now instantiated and may not have been at this point...  
		// Gotta fix this...
		if(!painting) {
			painting = GameObject.FindGameObjectWithTag("Painting").GetComponent<Painting>();
		}
		
		// Should only do when this this transform changes
		modelBrush.SetPosition(LocationOnGround());
		modelBrush.SetRotation(Quaternion.identity);
	}

	public override void ChangeColor(Color color) {
		modelBrush.SetColor(color);
	}

	public void OnButtonPress() {
Debug.Log("OnButtonPress - Loading model brushNum: " + brushNum);

		painting.AddModel(modelBrush);

		// Unlink model from brush pointer
		modelBrush = null;
		
		LoadNewBrushModel(ModelType.FindById(brushNum));
	}

	public void LoadNextBrushModel(int direction) {
		brushNum += direction;

		if(brushNum > 41) {
			brushNum = 0;
		} else if(brushNum < 0) {
			brushNum = 41;
		}
		LoadNewBrushModel(ModelType.FindById(brushNum));
	}

  public void ScaleUp() {
    AdjustScale(SCALE_UP_FACTOR);
  }

  public void ScaleDown() {
    AdjustScale(SCALE_DOWN_FACTOR);
  }

  private void AdjustScale(float scaleFactor) {
    scale *= scaleFactor;

    if(scale > MAX_SCALE) {
      scale = MAX_SCALE;
    } else if(scale < MIN_SCALE) {
      scale = MIN_SCALE;
    }

    modelBrush.SetScale(scale);
  }
}
