using UnityEngine;
using System.Collections;

public enum Character{
	ZedoRego,
	Lili,
	Menu
}

public class MenuCharacter : MonoBehaviour {
	public Character selectedChar;
	private SpriteRenderer sprRenderer;


	void Awake () {
		sprRenderer = GetComponent<SpriteRenderer>();
	}

	public void NextAnimation() {
		Debug.Log ("NextAnimation");
		GameObject.Find("MenuScreen").GetComponent<MenuScreen>().nextAnimation();
	}
	
	#region Selection Highlight
	void UpdateRendererColor(Color c){
		sprRenderer.color = c;
	}
	
	void OnMouseEnter(){
		Color c;
		ColorUtility.TryParseHtmlString("#AAAAAAFF", out c);
		iTween.ValueTo(gameObject, iTween.Hash(
			"from", sprRenderer.color, 
			"to", c,
			"time", 0.1f,
			"onupdate", "UpdateRendererColor"
			));
	}
	
	void OnMouseExit() {
		iTween.ValueTo(gameObject, iTween.Hash(
			"from", sprRenderer.color, 
			"to", Color.white,
			"time", 0.1f,
			"onupdate", "UpdateRendererColor"
			));
	}
	#endregion

	void OnMouseDown() {
		if(selectedChar == Character.ZedoRego){
			Debug.Log("Load zdorego about");
			Application.LoadLevel("ZedoRego");
		}
		else if(selectedChar == Character.Menu){
			Debug.Log("Load lili about");
			Application.LoadLevel("AboutLili");
		}
	}
}
