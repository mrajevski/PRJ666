using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class slotData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public itemController inventory;
	public int position;
	private Vector2 origin;
	public bool dragging = false, dataType = false;

	public void OnBeginDrag(PointerEventData eventData) {
		if (inventory.inventory [position].itemID != -1) {
			dragging = true;
			origin = this.transform.position;
			this.transform.position = eventData.position;
		}
	}

	public void OnDrag(PointerEventData eventData) {
		if (dragging) {
			this.transform.position = eventData.position;
		}
	}

	public void OnEndDrag(PointerEventData eventData) {
		if (dragging) {
			this.transform.position = origin;
			dragging = false;
		}
	}


}
