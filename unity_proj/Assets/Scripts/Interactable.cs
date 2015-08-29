using UnityEngine;
using System.Collections;
using Fungus;

public abstract class Interactable : MonoBehaviour{
	public Flowchart interactableFlowChart;
	protected ContextMenu contextMenu;

	protected virtual void Awake () {
		contextMenu = GameObject.FindObjectOfType<ContextMenu>();	
	}

	// Use this for initialization
	protected virtual void Start () {
		contextMenu.gameObject.SetActive(false);
	}

	public virtual void Observe() {
		Say("ObserveNoAction");
	}
	public virtual void Use() {
		Say("UseNoAction");
	}
	public virtual void Pick() {
		Say("PickNoAction");
	}
	public virtual void TalkTo() {
		Say("TalkToNoAction");
	}

	protected virtual void Say(string sayKey){
		Block sayBlock = interactableFlowChart.FindBlock("SayBlock");
		Say command = sayBlock.commandList[0] as Say;
		command.storyText = Texts.GetText(sayKey);
		sayBlock.Execute();
	}

}
