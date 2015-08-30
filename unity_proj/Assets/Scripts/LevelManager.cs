using UnityEngine;
using System.Collections;

public class LevelManager : Singleton<LevelManager> {

	public Interactable currentInteractable;
	public InventoryItem selectedItem;

	private ContextMenu ctxMenu;
	public ContextMenu GetContextMenu(){
		if (ctxMenu == null) {
			ctxMenu = GameObject.FindObjectOfType<ContextMenu>();
		}
		return ctxMenu;
	}

	public Interactable GetSelectedInteractable ()
	{
		return currentInteractable;
	}

	public void SetSelectedInteractable (Interactable interactable)
	{
		currentInteractable = interactable;
	}
}
