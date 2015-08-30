using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public class Interactable : MonoBehaviour{
	public bool isPickable = false;
	public GameObject observeObj, useObj, pickObj, talkObj;

	private ContextMenu contextMenu;
	private SpriteRenderer renderer;

	void Awake () {
		Assert.IsNotNull(observeObj);
		Assert.IsNotNull(useObj);
		Assert.IsNotNull(pickObj);
		Assert.IsNotNull(talkObj);

		contextMenu = LevelManager.Instance().GetContextMenu();
		renderer = GetComponent<SpriteRenderer>();
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
	void Start () {
		contextMenu.gameObject.SetActive(false);
	}

	public void Observe() {
		observeObj.SetActive(true);
	}
	public void Use() {
		useObj.SetActive(true);
	}
	public void Pick() {
		pickObj.SetActive(true);
	}
	public void TalkTo() {
		talkObj.SetActive(true);
	}

	void OnMouseDown() {
		if (LevelManager.Instance().clickLocked) return;
		LevelManager.Instance().SetSelectedInteractable(this);
		contextMenu.gameObject.SetActive(true);
	}

	#region Selection Highlight
	void UpdateRendererColor(Color c){
		renderer.color = c;
	}

	void OnMouseEnter(){
		if (LevelManager.Instance().clickLocked) return;
		Color c;
		Color.TryParseHexString("AAAAAAFF", out c);
		iTween.ValueTo(gameObject, iTween.Hash(
			"from", renderer.color, 
			"to", c,
			"time", 0.1f,
			"onupdate", "UpdateRendererColor"
		));
	}

	void OnMouseExit() {
		if (LevelManager.Instance().clickLocked) return;
		iTween.ValueTo(gameObject, iTween.Hash(
			"from", renderer.color, 
			"to", Color.white,
			"time", 0.1f,
			"onupdate", "UpdateRendererColor"
		));
	}
	#endregion

}
