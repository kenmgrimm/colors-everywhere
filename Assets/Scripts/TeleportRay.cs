using UnityEngine;

public class TeleportRay : MonoBehaviour {
	private const int NUM_DOTS = 30;
	private const float ARC_HEIGHT = .75f;
	private const float MAX_DISTANCE = 10f;
	private const float CAMERA_HEIGHT = 1.5f;

	private GameObject[] dots = new GameObject[NUM_DOTS];
	private GameObject rayDots;

	void Awake() {
		rayDots = new GameObject("Ray Dots");
		rayDots.transform.parent = transform;

		GameObject dotPrefab = Util.LoadPrefab("Teleport Line Dot");
		
		for(int i = 0; i < NUM_DOTS; i++) {
			dots[i] = (GameObject)Instantiate(dotPrefab, rayDots.transform);
		}
		DeActivateArc();

		GameObject.Find("Teleport Button").GetComponent<TeleportButton>().OnTeleport += Teleport;
		GameObject.Find("Magnetic Sensor Button").GetComponent<MagneticSensorButton>().OnButtonPressed += Teleport;
	}

	void Update() {
		Ray ray = Ray();

		Vector3 groundPos;
		if(!IsGrounded(ray, out groundPos)) { 
			DeActivateArc();
			return; 
		}

		DrawLine(ray.origin, groundPos);
	}

	public void Teleport() {
		Vector3 groundPos;
		if(IsGrounded(Ray(), out groundPos)) {
			Camera.main.transform.position = groundPos + new Vector3(0, CAMERA_HEIGHT, 0);
		}
	}

	private bool IsGrounded(Ray ray, out Vector3 groundPosition) {
		groundPosition = default(Vector3);

		RaycastHit[] hits = Physics.RaycastAll(ray);

		foreach(RaycastHit hit in hits) {
			if(hit.collider.gameObject.name == "Ground") {
				Debug.Log(ray.origin + ", " + hit.point + ", " + Vector3.Distance(ray.origin, hit.point));

				if(Vector3.Distance(ray.origin, hit.point) < MAX_DISTANCE) {
					groundPosition = hit.point;
					return true;
				}
			}
		}

		return false;
	}

	private void DeActivateArc() {
		rayDots.SetActive(false);
	}

	private void ActivateArc() {
		rayDots.SetActive(true);
	}

	private void DrawLine(Vector3 origin, Vector3 target) {
		Debug.Log("DrawLine: " + origin + ", " + target);

		float distance = Vector3.Distance(origin, target);
		Debug.Log("Distance: " + distance);

		for(int i = 0; i < NUM_DOTS; i++) {
			Vector3 lerpedPos = Vector3.Lerp(origin, target, (float)i / NUM_DOTS);
			
			float dotSpacing = 180f / NUM_DOTS;

			float yPos = Mathf.Sin(Mathf.Deg2Rad * i * dotSpacing) * ARC_HEIGHT;

			Vector3 position = lerpedPos + new Vector3(0, yPos, 0);
			dots[i].transform.position = position;
		}

		ActivateArc();
	}

	private Ray Ray() {
		Ray reticleRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		reticleRay.origin += Camera.main.transform.up * -0.3f;

		return reticleRay;
	}
}
