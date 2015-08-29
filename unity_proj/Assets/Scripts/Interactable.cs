using UnityEngine;
using System.Collections;
using Fungus;

public abstract class Interactable : MonoBehaviour{
	protected Flowchart interactableFlowChart;

	void Awake () {
		interactableFlowChart = GameObject.Find("InteractableFlowChart").GetComponent<Flowchart>();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
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
