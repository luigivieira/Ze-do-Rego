﻿using UnityEngine;
using System.Collections;

public class FireExtinguisherItem : InventoryItem {
	
	public override bool useItem() {
		Debug.Log("Fire Extinguisher used");
		return false;
	}
}
