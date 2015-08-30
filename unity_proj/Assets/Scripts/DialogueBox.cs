using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogueBox : MonoBehaviour {
	public Text title;
	public GameObject content;
	public Image avatar;
	public Canvas canvas;
	public TalkAction parentAction;
	public GameObject buttonPrefab;

	private List<Dialogue.Choice> choices;

	void Awake (){
		canvas.worldCamera = Camera.main;
		choices = new List<Dialogue.Choice>();
	}

	public void SetTitle (string title) {
		this.title.text = title;
	}

	public void AddChoice (Dialogue.Choice choice) {
		GameObject choiceButton = GameObject.Instantiate(buttonPrefab);
		choiceButton.transform.SetParent(content.transform, false);
		choiceButton.transform.localScale = new Vector3(1, 1, 1);

		Text btnText = choiceButton.transform.GetChild(0).GetComponent<Text>();
		btnText.text = choice.dialogue;

		this.choices.Add(choice);
		int count = this.choices.Count-1;
		choiceButton.GetComponent<Button>().onClick.AddListener( () => { 
			OnChoiceClicked(count);
		});
	}

	public void SetAvatar (Sprite avatar) {
		this.avatar.sprite = avatar;
	}

	public void HideAvatar ()
	{
		this.avatar.gameObject.SetActive(false);
	}

	void OnMouseDown() {
		Dismiss();
	}

	public void Dismiss(){
		iTween.FadeTo(this.gameObject, iTween.Hash("alpha", 0));
		Destroy(transform.parent.gameObject);
	}

	public void OnChoiceClicked(int choiceIndex){
			Debug.Log ("Button clicked = " + choiceIndex);
		Dialogue.Choice nextChoice = choices[choiceIndex];
		parentAction.NextChoice(nextChoice);
	}

	public void CleanChoices ()
	{
		this.choices.Clear();
		for(int i=0; i< content.transform.childCount;i++) {
			Transform child = content.transform.GetChild(i);
			child.parent = null;
			Destroy(child.gameObject);
		}
	}
}
