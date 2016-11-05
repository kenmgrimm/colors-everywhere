using UnityEngine;
using UnityEngine.EventSystems;

public class BrushButton : MonoBehaviour, IPointerClickHandler {
	// private static int LEFT = 0, RIGHT = 1, UP = 2, DOWN = 3;
	
	// public int direction;

	// private ModelBrush brush;
	// private int brushNum = 0;

	// void Awake () {
	// 	brush = GameObject.Find("ModelBrush").GetComponent<ModelBrush>();
	// }

	public void OnPointerClick( PointerEventData data ) {
	// 	if(direction == LEFT) {
	// 		brush.LoadNextBrushModel(-1);
	// 	} else if(direction == RIGHT) {
	// 		brush.LoadNextBrushModel(1);
	// 	} else if(direction == UP) {
	// 		brush.ScaleUp();
	// 	} else {
	// 		brush.ScaleDown();
	// 	}
	}
}
