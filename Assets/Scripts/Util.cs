using UnityEngine;
using System;

public static class Util {
	public static void LogException(Exception exception = null, string message = "") {
		string caller = new System.Diagnostics.StackFrame(1, true).GetMethod().Name;
		Debug.LogError(caller + ": " + message + "\n" + 
			exception.Message + "\n" + exception.StackTrace + "\n");
	}

	public static GameObject LoadPrefab(string path) {
		return (GameObject)Resources.Load("Prefabs/" + path);
	}

	public static GameObject Instantiate(string path, Transform parent = null) {
		return GameObject.Instantiate(LoadPrefab(path));
	}

	public static GameObject LoadAndCreatePrefab(string path, Transform parent = null) {
		GameObject newObject = GameObject.Instantiate(LoadPrefab(path));
		
		if(parent != null) {
			newObject.transform.parent = parent;
		}

		return newObject;
	}
}
