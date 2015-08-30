using UnityEngine;
using System.Collections;

public class StartDialogue : MonoBehaviour {

	public TalkAction action;

	void Awake() {
		LevelManager.Instance().clickLocked = true;
	}
	public void ActivateAction(){
		action.gameObject.SetActive(true);
	}
}
