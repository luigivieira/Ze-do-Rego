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

	private ToggleGroup group;
	void Awake() {
		group = GetComponent<ToggleGroup>();
	}

	public void addItem (InventoryItem item){
		item.transform.SetParent(this.transform);
		item.transform.localScale = Vector3.one;
		item.GetComponent<Toggle>().group = this.group;
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
			if(selectedItem.useItem()){
				removeItem(selectedItem);
			}
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
