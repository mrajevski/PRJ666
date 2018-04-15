using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class slotHandler : MonoBehaviour, IDropHandler {
	public itemController inventory;
	public int position;
	public bool slotType = false; // true - equipment, false - inventory

	public void OnDrop(PointerEventData eventData) {
		slotData droppedItem = eventData.pointerDrag.GetComponent<slotData> ();
			if (droppedItem.dataType != slotType) {
				if (!slotType)
					inventory.swap (position, droppedItem.position);		
				else 
					inventory.swap (droppedItem.position, position);
			} else {
				if (slotType)
					inventory.e2e (position, droppedItem.position);
				else 
					inventory.i2i (position, droppedItem.position);
			}

	}
}
