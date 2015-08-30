using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float playerSpeed;

	private Inventory inv;
	private Vector3 nextDestination;
	void Awake() {
		nextDestination = transform.position;
		inv = FindObjectOfType<Inventory>();
	}
	void Update() {
		if(Input.GetMouseButtonDown(0) && GameObject.FindObjectOfType<ContextMenu>() == null){
			FindPath.Instance().SetDestination(Camera.main.ScreenToWorldPoint(Input.mousePosition));
		}
		if (FindPath.Instance().HasDestination()) {
			if (nextDestination == transform.position && FindPath.Instance().HasDestination()){
				nextDestination = FindPath.Instance().DoStep(FindPath.Instance().GetCurrentWaypoint(transform.position)).transform.position;
				GoToNextPoint();
			}
		}
	}

	void GoToNextPoint() {
		iTween.MoveTo(gameObject, iTween.Hash(
			"position", nextDestination,
			"speed", playerSpeed,
			"easetype", "linear"
		));
	}
	public void PickUpCollectable(){
		Interactable selectedInteractive = LevelManager.Instance().currentInteractable;
		if (selectedInteractive.isPickable){
			inv.addItem(LevelManager.Instance().selectedItem);
			Destroy(selectedInteractive.gameObject);
		}
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
