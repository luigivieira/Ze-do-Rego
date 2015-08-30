using UnityEngine;
using System.Collections;

public class FireExtinguisherItem : InventoryItem {
	
	public override void useItem() {
		Debug.Log("Fire Extinguisher used");
	}
}
