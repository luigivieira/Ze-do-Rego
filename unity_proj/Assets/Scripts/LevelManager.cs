using UnityEngine;
using System.Collections;

public class LevelManager : Singleton<LevelManager> {

	#region Player Interaction Variables
	public bool talkedToAviso = false;
	public bool observedAviso = false;
	public bool observedFireExtinguisher = false;
	#endregion

	public Interactable currentInteractable;
	public InventoryItem selectedItem;
	public bool clickLocked = false;

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
