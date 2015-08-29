using UnityEngine;
using System.Collections;

public class ContextMenu : MonoBehaviour {

	//public Fungus.Flowchart interactablesFlowChart;
	private Interactable selectedObject;
	
	void Start () {
		selectedObject = LevelManager.Instance().GetSelectedInteractable();
		Vector3 closerPosition = selectedObject.transform.position;
		SpriteRenderer closerRenderer = selectedObject.GetComponent<SpriteRenderer>();
		this.transform.Translate(new Vector3(closerPosition.x+closerRenderer.bounds.size.x,
		                                     closerPosition.y+2,0));
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {		
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			bool canDismiss = hit.collider == null;
			if(canDismiss){
				dismiss();
			}
		}
	}

	private void dismiss() {
		this.gameObject.SetActive(false);
	}
		
	public void DoPickItem(){
		selectedObject.Pick();
		dismiss();
	}

	public void DoObserve() {
		selectedObject.Observe();
		dismiss();
	}

	public void DoUse() {
		selectedObject.Use();
		dismiss();
	}

	public void DoTalkTo() {
		selectedObject.TalkTo();
		dismiss();
	}
}
