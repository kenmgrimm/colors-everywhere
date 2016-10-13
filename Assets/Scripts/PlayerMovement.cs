using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	void Start () { }
	void Update () { }

	public void Move(Vector2 move){
    // Debug.Log("Move");
    // Debug.Log(move);
	}

	public void MoveSpeed(Vector2 move){
    Debug.Log("MoveSpeed");
    Debug.Log(move);

		transform.Rotate(new Vector3(0, move.x, 0));
		transform.position += transform.forward * move.y;
	}
}
