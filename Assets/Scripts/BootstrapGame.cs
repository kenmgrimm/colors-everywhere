using UnityEngine;

public class BootstrapGame : MonoBehaviour {
	void Awake () {
		Util.LoadAndCreatePrefab("Game");
	}
}
