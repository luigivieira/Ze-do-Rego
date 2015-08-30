using UnityEngine;
using System.Collections;

public class TalkAction : MonoBehaviour {
	public DialogueFile dialogFile;
	public string dialogName;
	public int startIndex;
	public GameObject dialogueBoxPrefab;
	private DialogueBox dialogueBox;
	private Dialogue currentDialogue;
	private Dialogue.Choice currentChoice;
	private Dialogue.Choice[] nextChoices;

	// Use this for initialization
	void OnEnable () {
		DialogueManager manager = DialogueManager.LoadDialogueFile(dialogFile);
		currentDialogue = manager.GetDialogue(dialogName);
		Dialogue.Choice[] choices = currentDialogue.GetChoices();
		Debug.Log(choices.Length);
		if(choices.Length > 0 ){
			if(choices.Length == 1) {
				currentChoice = choices[0];
				currentDialogue.PickChoice(currentChoice);
				nextChoices = currentDialogue.GetChoices();
			}
			else {
				nextChoices = choices;
			}
			SetupDialogueBox();
			
			this.gameObject.SetActive(false);
		}
	}

	private Sprite GetImageFromResources(string speaker){
		return Resources.Load<Sprite>("DialogueAvatars/"+speaker);
	}

	private void SetupDialogueBox() {
		if(dialogueBox == null){
			GameObject prefabInstance = GameObject.Instantiate(dialogueBoxPrefab);
			dialogueBox = prefabInstance.transform.GetChild(0).GetComponent<DialogueBox>();
		}
		else {
			dialogueBox.CleanChoices();
		}
		dialogueBox.parentAction = this;
		Dialogue.Choice choice;
		if(currentChoice == null){
			choice = nextChoices[0];
			foreach (var nextChoice in nextChoices) {
				dialogueBox.AddChoice(nextChoice);
			} 		
		}
		else {
			choice = currentChoice;
			dialogueBox.AddChoice(currentChoice);
		}
		dialogueBox.SetTitle(choice.speaker);
		Sprite avatar = GetImageFromResources(choice.speaker);
		if(avatar != null) dialogueBox.SetAvatar(avatar);
		else dialogueBox.HideAvatar();
	}

	public void NextChoice(Dialogue.Choice nextChoice) {
		currentDialogue.PickChoice(nextChoice);
		nextChoices = currentDialogue.GetChoices();
		Debug.Log(nextChoices.Length);
		if(nextChoices.Length > 0){	
			currentChoice = null;
			if(nextChoices.Length == 1) {
				currentChoice = nextChoices[0];
				currentDialogue.PickChoice(currentChoice);
				nextChoices = currentDialogue.GetChoices();
			}
			SetupDialogueBox();
		}
		else {
			dialogueBox.Dismiss();
		}
	}
}
