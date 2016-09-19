using System;

[Serializable]
public struct CompressedVector3 {
  public string x;
  public string y;
  public string z;

  public CompressedVector3(float x, float y, float z) {
    this.x = Math.Round((Decimal)x, 3).ToString();
    this.y = Math.Round((Decimal)y, 3).ToString();
    this.z = Math.Round((Decimal)z, 3).ToString();
  }
}