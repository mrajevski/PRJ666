using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class deleteHandler : MonoBehaviour, IDropHandler {
	public itemController inventory;

	public void OnDrop(PointerEventData eventData) {
		slotData droppedItem = eventData.pointerDrag.GetComponent<slotData> ();
		if (!droppedItem.dataType && inventory.inventory[droppedItem.position].itemID != -1)
			inventory.removeItem (droppedItem.position);
	}
}
