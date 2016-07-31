using UnityEngine;
using System.Collections;

public class ReplaceWebcamImage : MonoBehaviour {
	public Material cameraPlaneMat;

	void Start() {
		Material[] materials = new Material[1];
		materials[0] = cameraPlaneMat;
		GetComponent<Renderer>().materials = materials;
	}
}
