using UnityEngine;

public class Test : MonoBehaviour {
  public void Run() {
    string json = "{\"paintingSummaries\":[{\"id\":28,\"latitude\":2.09999990463257,\"longitude\":2.09999990463257,\"direction_degrees\":10}," + 
      "{\"id\":29,\"latitude\":2.09999990463257,\"longitude\":2.09999990463257,\"direction_degrees\":10}]}";

    JSONObject jsonObj = new JSONObject(json);
    Debug.Log("************************************************************");
    Debug.Log(jsonObj.GetField("paintingSummaries").list[0].GetField("latitude").n);
  }

  void Awake() {
    Run();
  }
}