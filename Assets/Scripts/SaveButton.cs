using UnityEngine.EventSystems;

public class SaveButton : EventTrigger {
	public override void OnPointerClick( PointerEventData data ) {
		PaintingGameManager manager = PaintingGameManager.instance;
		Painting painting = manager.Painting();

		PaintingPersistence persist = painting.GetComponent<PaintingPersistence>();
		persist.SavePainting();
	}
}
