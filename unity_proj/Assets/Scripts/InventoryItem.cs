using UnityEngine;
using System.Collections;

[System.Serializable]
public abstract class InventoryItem : MonoBehaviour{
	/**
	 * Base class to create items to add to inventory
	 */

	public abstract void useItem();

}
