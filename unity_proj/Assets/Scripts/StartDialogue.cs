using UnityEngine;
using System.Collections;

public class StartDialogue : MonoBehaviour {

	public TalkAction action;

	public void ActivateAction(){
		action.gameObject.SetActive(true);
	}
}
