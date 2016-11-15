using UnityEngine;

public class TeleportReticle : MonoBehaviour {
	private const int NUM_DOTS = 50;
	private const float ARC_HEIGHT = 1f;
	private const float CAMERA_HEIGHT = 1.5f;

	private GameObject[] dots = new GameObject[NUM_DOTS];

	void Awake() {
		GameObject dotPrefab = Util.LoadPrefab("Teleport Line Dot");
		
		for(int i = 0; i < NUM_DOTS; i++) {
			dots[i] = Instantiate(dotPrefab);
			dots[i].SetActive(false);
		}

		GameObject.Find("Teleport Button").GetComponent<TeleportButton>().OnTeleport += Teleport;
	}

	void Update() {
		Ray ray = TeleportRay();

		Vector3 groundPos;
		if(!IsGrounded(ray, out groundPos)) { return; }

		DrawLine(ray.origin, groundPos);
	}

	public void Teleport() {
		Vector3 groundPos;
		if(IsGrounded(TeleportRay(), out groundPos)) {
			Camera.main.transform.position = groundPos + new Vector3(0, CAMERA_HEIGHT, 0);
		}
	}

	private bool IsGrounded(Ray ray, out Vector3 groundPosition) {
		groundPosition = default(Vector3);

		RaycastHit[] hits = Physics.RaycastAll(ray);

		foreach(RaycastHit hit in hits) {
			if(hit.collider.gameObject.name == "Ground") {
				groundPosition = hit.point;
				return true;
			}
		}

		return false;
	}

	private void DrawLine(Vector3 origin, Vector3 target) {
		Debug.Log("DrawLine: " + origin + ", " + target);
		origin.x -= 0.1f;
		origin.y -= 0.1f;

		float distance = Vector3.Distance(origin, target);
		Debug.Log("Distance: " + distance);

		for(int i = 0; i < NUM_DOTS; i++) {
			Vector3 lerpedPos = Vector3.Lerp(origin, target, (float)i / NUM_DOTS);
			
			float dotSpacing = 180f / NUM_DOTS;

			float yPos = Mathf.Sin(Mathf.Deg2Rad * i * dotSpacing) * ARC_HEIGHT;

			Vector3 position = lerpedPos + new Vector3(0, yPos, 0);
			dots[i].transform.position = position;

			dots[i].SetActive(true);
		}
	}

	private Ray TeleportRay() {
		return Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
	}
}
