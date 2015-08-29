using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public class Interactable : MonoBehaviour{
	public GameObject observeObj, useObj, pickObj, talkObj;

	private ContextMenu contextMenu;

	protected virtual void Awake () {
		Assert.IsNotNull(observeObj);
		Assert.IsNotNull(useObj);
		Assert.IsNotNull(pickObj);
		Assert.IsNotNull(talkObj);

		contextMenu = LevelManager.Instance().GetContextMenu();
		observeObj = Instantiate(observeObj);
		observeObj.SetActive(false);
		useObj = Instantiate(useObj);
		useObj.SetActive(false);
		pickObj = Instantiate(pickObj);
		pickObj.SetActive(false);
		talkObj = Instantiate(talkObj);
		talkObj.SetActive(false);
	}

	// Use this for initialization
	protected virtual void Start () {
		contextMenu.gameObject.SetActive(false);
	}

	public virtual void Observe() {
		observeObj.SetActive(true);
	}
	public virtual void Use() {
		useObj.SetActive(true);
	}
	public virtual void Pick() {
		pickObj.SetActive(true);
	}
	public virtual void TalkTo() {
		talkObj.SetActive(true);
	}
	void OnMouseDown() {
		LevelManager.Instance().SetSelectedInteractable(this);
		contextMenu.gameObject.SetActive(true);
	}

}
