using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class slotData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public itemController inventory;
	public int position;
	private Vector2 origin;
	private Transform originParent;
	public bool dragging = false, dataType = false; // true - equipment, false - inventory

	/*
	*	Create new instance of object outside of the slot
	*	to fix the right to left swap problem
	*/


	public void OnBeginDrag(PointerEventData eventData) {
		if ((!dataType && inventory.inventory [position].itemID == -1) || (dataType && inventory.equipment [position].itemID == -1)) {
			dragging = true;
			origin = this.transform.position;
			originParent = this.transform.parent;
			this.transform.SetParent (GameObject.Find("Inventory UI").transform);
			this.transform.position = eventData.position;
		}
	}

	public void OnDrag(PointerEventData eventData) {
		if (dragging) 
			this.transform.position = eventData.position;
	}

	public void OnEndDrag(PointerEventData eventData) {
		if (dragging) {
			dragging = false;
			this.transform.SetParent (originParent);
			this.transform.position = origin;
		}
	}
}
