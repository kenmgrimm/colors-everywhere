using UnityEngine.EventSystems;

public class TeleportButton : EventTrigger {
	public delegate void TeleportHandler();
  public event TeleportHandler OnTeleport;

	public override void OnPointerClick( PointerEventData data ) {
    if(OnTeleport != null) {
      OnTeleport();
    }
	}
}
