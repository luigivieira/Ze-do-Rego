using UnityEngine;
using System.Collections;

public class ContextMenu : MonoBehaviour {

	public Fungus.Flowchart interactablesFlowChart;
	private GameObject selectedObject;
	
	private bool dismissEnabled;

	// Use this for initialization
	void Awake () {
//		interactablesFlowChart = GameObject.Find("InteractableFlowChart").GetComponent<Fungus.Flowchart>();
	}

	void Start () {
		string selectedObjectName = interactablesFlowChart.GetStringVariable("selectedInteractable");
		selectedObject = GameObject.Find(selectedObjectName);
		Vector3 closerPosition = selectedObject.transform.position;
		SpriteRenderer closerRenderer = selectedObject.GetComponent<SpriteRenderer>();
		this.transform.Translate(new Vector3(closerPosition.x+closerRenderer.bounds.size.x,
		                                     closerPosition.y+2,0));
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {		
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			bool canDismiss = IsShowingCtxMenu() && hit.collider == null;
			if(canDismiss){
				dismiss();
			}
		}
	}

	public void SetFlowChart(Fungus.Flowchart flowchart){
		Debug.Log(flowchart.name);
		interactablesFlowChart = flowchart;
	}

	private void dismiss() {
		this.gameObject.SetActive(false);
		dismissEnabled = false;
		SetShowingCtxMenu(false);
	}
		
	private bool IsShowingCtxMenu(){
		return interactablesFlowChart.GetBooleanVariable("showingCtxMenu") && dismissEnabled;
	}
	
	private void SetShowingCtxMenu(bool enabled){
		interactablesFlowChart.SetBooleanVariable("showingCtxMenu", enabled);
	}
	
	public void enableMenuDismiss() {
		dismissEnabled = true;
	}

	public void DoPickItem(){
		interactablesFlowChart.SendFungusMessage("pickSelected");
		dismiss();
	}

	public void DoObserve() {
		selectedObject.GetComponent<Interactable>().Observe();
		dismiss();
	}

	public void DoUse() {
		dismiss();
	}

	public void DoTalkTo() {
		selectedObject.GetComponent<Interactable>().TalkTo();
		dismiss();
	}


}
