using UnityEngine;

public class Swim : MonoBehaviour {
	private static float ROTATE_FACTOR = 5f;
	
	void Update() {
		transform.Rotate(Vector3.up * Time.deltaTime * ROTATE_FACTOR);
	}
}
