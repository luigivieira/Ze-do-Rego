using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireExtinguisherUseAction : TalkAction {

	// Use this for initialization
	protected override void OnEnable () {
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
				List<Dialogue.Choice> choicesToUse = new List<Dialogue.Choice>();
				foreach (Dialogue.Choice choice in choices) {
						if((choice.userData.Contains("talkedToWarning") && LevelManager.Instance().talkedToAviso) || 
					        (!choice.userData.Contains("talkedToWarning") && !LevelManager.Instance().talkedToAviso)){
						choicesToUse.Add (choice);
					}
				}
				nextChoices = choicesToUse.ToArray();
			}
			SetupDialogueBox();
			
			this.gameObject.SetActive(false);
		}
	}	
}
