using UnityEngine;
using UnityEngine.UI;

public class ModelBrush : Brush {
	private static float MIN_EXTENSION = 0.01f;  // I think should be >= near clipping plane 
	private static float EXTENSION_FACTOR = 0.5f;

	private float pointerLength;

	private Camera paintingCamera;

	private ModelType defaultModelType;
	private Model modelBrush;

	private Painting painting;


	void Awake() {
		paintingCamera = GameObject.Find("Painting Camera").GetComponent<Camera>();

		// Should not be created here, should exist and be looked up after selection on the brush palette
		defaultModelType = new ModelType(0, "Wobbly Tree", "tree_04_05", "None Yet"); 
		CreateNewBrushModel(defaultModelType);

		// Need to set starting pointerLength using extension slider.  Refactor and de-couple some of this stuff
		// DE-COUPLE
		float sliderValue = GameObject.Find("Extension Slider").GetComponent<Slider>().value;
		
		Extend(sliderValue);
	}

	public void CreateNewBrushModel(ModelType modelType) {
		Debug.Log("CreateNewBrushModel");
		modelBrush = modelType.CreateInstance(LocationOnGround(), Quaternion.identity, Color.blue, transform).GetComponent<Model>();		
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
		Debug.Log(LocationOnGround());

		modelBrush.SetRotation(Quaternion.identity);
		// modelBrush.SetRotation(transform.rotation);
	}

	public override void ChangeColor(Color color) {
		modelBrush.SetColor(color);
	}

	public void OnButtonPress() {
		Debug.Log("OnButtonPress");

		modelBrush.transform.parent = null;
		painting.AddModel(modelBrush);
		
		CreateNewBrushModel(defaultModelType);
	}
}
