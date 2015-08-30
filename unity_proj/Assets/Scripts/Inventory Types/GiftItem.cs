using UnityEngine;
using System.Collections;

public class GiftItem : InventoryItem {
	
	public override bool useItem() {
		Debug.Log("Fire Extinguisher used");
		return false;
	}
}
