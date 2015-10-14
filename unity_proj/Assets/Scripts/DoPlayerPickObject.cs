using UnityEngine;
using System.Collections;

public class DoPlayerPickObject : MonoBehaviour {
	public InventoryItem itemToPickUp;

	private Player currentPlayer;
	//private Inventory invMgr;
	void Start() {
		itemToPickUp = Instantiate(itemToPickUp);
		//invMgr = GameObject.FindObjectOfType<Inventory>();
		//invMgr.addItem(itemToPickUp);
		LevelManager.Instance().selectedItem = itemToPickUp;
		currentPlayer = GameObject.FindObjectOfType<Player>();
		currentPlayer.MoveToCollectable();
	}
	
}
