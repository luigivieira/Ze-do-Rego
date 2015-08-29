using UnityEngine;
using System.Collections;

public class ContextMenu : MonoBehaviour {

	public Fungus.Flowchart interactablesFlowChart;

	private GameObject selectedObject;

	// Use this for initialization
	void Awake () {
		interactablesFlowChart = GameObject.Find("InteractableFlowChart").GetComponent<Fungus.Flowchart>();
	}

	void Start () {
		string selectedObjectName = interactablesFlowChart.GetStringVariable("selectedInteractable");
		selectedObject = GameObject.Find(selectedObjectName);
		Vector3 closerPosition = selectedObject.transform.position;
		this.transform.Translate(new Vector3(closerPosition.x+2,closerPosition.y+2,0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMouseDown(){
		interactablesFlowChart.SendFungusMessage("pickSelected");
//		Destroy(selectedObject);
	}
}
