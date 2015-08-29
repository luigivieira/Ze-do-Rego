using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public Fungus.Flowchart interactablesFlowChart;
	public ContextMenu ctxMenu;

	private bool ctxMenuDismissEnabled;

	public static Fungus.Flowchart getInteractableFlow(){
		return GameObject.Find("LevelManager").GetComponent<LevelManager>().interactablesFlowChart;
	}

	void Awake () {
		interactablesFlowChart = GameObject.Find("InteractableFlowChart").GetComponent<Fungus.Flowchart>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(IsShowingCtxMenu() && Input.GetMouseButtonDown(0)){
			ctxMenu.gameObject.SetActive(false);
			ctxMenuDismissEnabled = false;
			SetShowingCtxMenu(false);
		}
	}

	private bool IsShowingCtxMenu(){
		return interactablesFlowChart.GetBooleanVariable("showingCtxMenu") && ctxMenuDismissEnabled;
	}

	private void SetShowingCtxMenu(bool enabled){
		interactablesFlowChart.SetBooleanVariable("showingCtxMenu", enabled);
	}

	public void enableCtxMenuDismiss() {
		ctxMenuDismissEnabled = true;
	}


}
