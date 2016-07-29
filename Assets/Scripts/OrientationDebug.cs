using UnityEngine;
 
public class OrientationDebug : MonoBehaviour {
  private float length = 0.5f;

  // private Color lightRed = new Color(1f, 0.4f, 0.4f);     // X
  // private Color lightGreen = new Color(0.4f, 1f, 0.4f);   // Y
  // private Color lightBlue = new Color(0.4f, 0.4f, 1f);    // Z

  private GameObject xObject;
  private GameObject yObject;
  private GameObject zObject;

  private LineRenderer xLine;
  private LineRenderer yLine;
  private LineRenderer zLine;

  //  private Color lightMagenta = Color.magenta - new Color(0.25f, 0.25f, 0.25f);

  private GameObject globalCenter;
  private GameObject localCenter;

  public bool showLocalOrientation = false;
  public bool showGlobalOrientation = false;

  public bool showLocalCenter = false;
  public bool showGlobalCenter = false;

  void Start() {
    xObject = new GameObject("X");
    xObject.layer = LayerMask.NameToLayer("Augmented Objects");
    xObject.transform.parent = transform;
    xObject.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 1);

    yObject = new GameObject("Y");
    yObject.layer = LayerMask.NameToLayer("Augmented Objects");
    yObject.transform.parent = transform;
    yObject.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 1);
    
    zObject = new GameObject("Z");
    zObject.layer = LayerMask.NameToLayer("Augmented Objects");
    zObject.transform.parent = transform;
    zObject.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 1);
    // GameObject globalCenterPrefab = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/GlobalCenter.prefab", typeof(GameObject));
    // GameObject localCenterPrefab = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/LocalCenter.prefab", typeof(GameObject));

    // globalCenter = Instantiate(globalCenterPrefab);
    // localCenter = Instantiate(localCenterPrefab);

    // globalCenter.name = gameObject.name + " Global Center";
    // localCenter.name = gameObject.name + " Local Center";

    // globalCenter.SetActive(false);
    // localCenter.SetActive(false);

    xLine = (LineRenderer)xObject.AddComponent<LineRenderer>();
    xLine.material = new Material(Shader.Find("Particles/Additive"));
    xLine.SetColors(Color.red, Color.red);
    xLine.SetWidth(0.01f, 0.01f);
    xLine.SetVertexCount(2);

    yLine = (LineRenderer)yObject.AddComponent<LineRenderer>();
    yLine.material = new Material(Shader.Find("Particles/Additive"));
    yLine.SetColors(Color.green, Color.green);
    yLine.SetWidth(0.01f, 0.01f);
    yLine.SetVertexCount(2);
    
    zLine = (LineRenderer)zObject.AddComponent<LineRenderer>();
    zLine.material = new Material(Shader.Find("Particles/Additive"));
    zLine.SetColors(Color.blue, Color.blue);
    zLine.SetWidth(0.01f, 0.01f);
    zLine.SetVertexCount(2);
  }

	void Update() {
    Vector3 origin = transform.position;
    Vector3 direction;
    Vector3 endPoint;
    Vector3 yDirection = transform.up;
    Vector3 zDirection = transform.right;

    xLine.SetPosition(0, origin);
    yLine.SetPosition(0, origin);
    zLine.SetPosition(0, origin);

    direction = transform.right;
    endPoint = origin + direction * 100;
    xLine.SetPosition(1, endPoint);

    direction = transform.up;
    endPoint = origin + direction * 100;
    yLine.SetPosition(1, endPoint);

    direction = transform.forward;
    endPoint = origin + direction * 100;
    zLine.SetPosition(1, endPoint);

    // if(showGlobalCenter) {
    //   globalCenter.SetActive(true);
    //   globalCenter.transform.position = transform.position;
    // } else {
    //   globalCenter.SetActive(false);
    // }

    // if(showLocalCenter) {
    //   localCenter.SetActive(true);
    //   localCenter.transform.position = transform.localPosition;
    // } else {
    //   localCenter.SetActive(false);
    // }
  }
}