using UnityEngine;
using System.Collections;
using Fungus;

public class NPC : Interactable {
	public Flowchart dialogFlowChart;

	public override void TalkTo() {
		dialogFlowChart.SendFungusMessage("StartChat");
	}

	public void OnMouseDown(){
		contextMenu.SetFlowChart(this.interactableFlowChart);	
	}
}
