using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
	/**
	 * Inventory system
	 * 
	 * functions needed:
	 * - Add item to inventory
	 * - Use item from inventory
	 * - Get inventory items
	 * - (un)Select item and get selected item
	 */
	// Use this for initialization

	public void addItem (InventoryItem item){
		item.transform.parent = this.transform;
	}

	public InventoryItem GetSelectedItem() {
		foreach(Transform child in transform){
			Toggle t = child.GetComponent<Toggle>();
			if (t.isOn){
				return child.GetComponent<InventoryItem>();
			}
		}
		return null;
	}

	public void useSelectedItem () {
		InventoryItem selectedItem = GetSelectedItem();
		if (selectedItem != null) {
			selectedItem.useItem();
			removeItem(selectedItem);
		}
	}

	public void removeItem (InventoryItem item) {
		foreach(Transform child in transform){
			if (child.GetInstanceID() == item.transform.GetInstanceID()){
				Destroy(child.gameObject);
				return;
			}
		}
	}
}
