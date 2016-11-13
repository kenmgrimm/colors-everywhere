using UnityEngine;

public class BootstrapGame : MonoBehaviour {
	void Awake () {
		Util.LoadAndCreatePrefab("Painting Game Manager");
	}
}
