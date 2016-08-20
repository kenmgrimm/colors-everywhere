public class PaintingSummary {
  public long id;
	public double latitude;
  public double longitude;
  public double direction_degrees;

  public PaintingSummary(long id, double latitude, double longitude, double direction_degrees) {
    this.id = id;
    this.latitude = latitude;
    this.longitude = longitude;
    this.direction_degrees = direction_degrees;
  }
}
