using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class slotData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public itemController inventory;
	public int position;
	private Vector2 origin;
	public bool dragging = false, dataType = false; // true - equipment, false - inventory

	public void OnBeginDrag(PointerEventData eventData) {
		if ((!dataType && inventory.inventory [position].itemID != -1) || (dataType && inventory.equipment [position].itemID != -1)) {
			dragging = true;
			origin = this.transform.position;
			this.transform.position = eventData.position;
			this.transform.position += new Vector3 (0.0f, 0.0f, 1.0f);
		}
	}

	public void OnDrag(PointerEventData eventData) {
		if (dragging) {
			this.transform.position = eventData.position;
		}
	}

	public void OnEndDrag(PointerEventData eventData) {
		if (dragging) {
			dragging = false;
			this.transform.position = origin;
			this.transform.position -= new Vector3 (0.0f, 0.0f, 1.0f);
		}
	}


}
