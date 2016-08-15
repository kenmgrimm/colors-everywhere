using UnityEngine;

public static class Util {
	public static GameObject LoadPrefab(string path) {
		return (GameObject)Resources.Load("Prefabs/" + path);
	}

	public static GameObject LoadAndCreatePrefab(string path, Transform parent = null) {
		GameObject newObject = GameObject.Instantiate(LoadPrefab(path));
		
		if(parent != null) {
			newObject.transform.parent = parent;
		}

		return newObject;
	}
}
