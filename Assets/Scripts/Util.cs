using UnityEngine;

public static class Util {
	public static GameObject LoadPrefab(string path) {
		return (GameObject)Resources.Load("Prefabs/" + path);
	}
}
