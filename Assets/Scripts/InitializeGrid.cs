using UnityEngine;
using System.Collections;

public class InitializeGrid : MonoBehaviour {
	private float MIN_RANGE = -3f;
	private float MAX_RANGE = 3f;
	private float INCREMENT = 0.5f;

	private GameObject gridBlock;

	void Start () {
		// gridBlock = GameObject.Find("Grid Block");

		// for(float x = MIN_RANGE; x < MAX_RANGE; x+= INCREMENT) {
		// 	for(float y = MIN_RANGE; y < MAX_RANGE; y+= INCREMENT) {
		// 		for(float z = MIN_RANGE; z < MAX_RANGE; z+= INCREMENT) {
		// 			Instantiate(gridBlock, new Vector3(x, y, z), Quaternion.identity);
		// 		}
		// 	}
		// }
	}

}
