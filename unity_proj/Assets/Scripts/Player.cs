using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float playerSpeed;
	//public Fungus.Flowchart interactablesFlowChart;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PickUpCollectable(){
		GameObject selectedInteractive = LevelManager.Instance().currentInteractable.gameObject;
		Destroy(selectedInteractive);
		//string toPickName = interactablesFlowChart.GetStringVariable("selectedInteractable");
		//GameObject toPick = GameObject.Find(toPickName);
		//TODO: Send to inventory
		//Destroy(toPick);
	}

	public void MoveToCollectable(){
		//string toPickName = interactablesFlowChart.GetStringVariable("selectedInteractable");
		//GameObject toPick = GameObject.Find(toPickName);
		//TODO: use callback to set item in inventory
		//Fungus.iTween.MoveTo(this.gameObject, toPick.transform.position, 1);
		Transform selectedInteractable = LevelManager.Instance().currentInteractable.transform;
		iTween.MoveTo(gameObject, iTween.Hash(
			"position", selectedInteractable.position,
			"speed", playerSpeed,
			"oncompletetarget", gameObject,
			"oncomplete", "PickUpCollectable",
			"easetype", "linear"
		));
	}
}
