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
	public GameObject textContainer;

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

		AdjustChoiceButtonHeight(choiceButton, btnText);
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
		var children = new List<GameObject>();
		foreach (Transform child in content.transform) children.Add(child.gameObject);
		children.ForEach(child => Destroy(child));
	}

	#region Private functions
	/// <summary>
	/// Adjusts the height of the choice button.
	/// </summary>
	/// <param name="choiceButton">Choice button <see cref="GameObject"/>.</param>
	/// <param name="choiceButtonText">Choice button <see cref="Text"/>.</param>
	private void AdjustChoiceButtonHeight(GameObject choiceButton, Text choiceButtonText){
		RectTransform textContainerSize = textContainer.GetComponent<RectTransform>();
		LayoutElement btnLayout = choiceButton.GetComponent<LayoutElement>();	
		
		btnLayout.preferredHeight = CalculateTextHeight(textContainerSize.rect.width,
		                                                choiceButtonText.text,
		                                                choiceButtonText.font,
		                                                choiceButtonText.fontSize,
		                                                choiceButtonText.fontStyle);
	}

	/// <summary>
	/// Calculates text height accordingly with maxWidth and font settings.
	/// </summary>
	/// <returns>The text height.</returns>
	/// <param name="maxWidth">Max width to constrain text</param>
	/// <param name="text">Text string value</param>
	/// <param name="font"><see cref="Font"/></param>
	/// <param name="fontSize">font size </param>
	/// <param name="fontStyle"><see cref="FontStyle"/></param>
	private float CalculateTextHeight(float maxWidth, string text, Font font, 
	                                  int fontSize, FontStyle fontStyle){
		GUIStyle s = new GUIStyle();
		s.font = font;
		s.fontSize = fontSize;
		s.fontStyle = fontStyle;
		s.wordWrap = true;
		s.richText = true;
		
		float height = s.CalcHeight(new GUIContent(text), Mathf.Abs(maxWidth));
		
		return height;
	}

	/// <summary>
	/// Calculates the text height with generator.
	/// 
	/// Usage example, the 0.6 is a default good value:		
	/// CalculateTextHeightWithGenerator(textContainerSize.rect.width,
	//		                                 choice.dialogue,
	//		                                 0.6f,
	//		                                 btnText.font,
	//		                                 btnText.fontSize,
	//		                                 btnText.fontStyle);
	/// </summary>
	/// <returns>The text height with generator.</returns>
	/// <param name="maxWidth">Max width.</param>
	/// <param name="text">Text.</param>
	/// <param name="reducePercentage">Reduce percentage.</param>
	/// <param name="font">Font.</param>
	/// <param name="fontSize">Font size.</param>
	/// <param name="fontStyle">Font style.</param>
	private float CalculateTextHeightWithGenerator(float maxWidth, string text, 
	                                               float reducePercentage, Font font, 
	                                               int fontSize, FontStyle fontStyle){

		TextGenerationSettings settings = new TextGenerationSettings();
		settings.textAnchor = TextAnchor.UpperLeft;
		settings.generationExtents = new Vector2(maxWidth, 0);
		settings.pivot = Vector2.zero;
		settings.richText = true;
		settings.lineSpacing = 0.1f;
		settings.font = font;
		settings.fontSize = fontSize;
		settings.fontStyle = fontStyle;
		settings.verticalOverflow = VerticalWrapMode.Overflow;
		TextGenerator generator = new TextGenerator();
		generator.Populate(text, settings);
		float height = generator.GetPreferredHeight(text, settings);

		return height * reducePercentage;
	}
	#endregion
}
