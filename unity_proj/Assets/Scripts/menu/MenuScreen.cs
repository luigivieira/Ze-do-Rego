using UnityEngine;
using System.Collections;

enum CurrentMenuAnimation 
{
	Vespa,
	AirPlane,
	Cow,
}

public class MenuScreen : MonoBehaviour {
	public Animator titleAnimator;
	public Animator zedoregoVespaAnimator;
	public Animator zedoregoPlaneAnimator;
	public Animator liliAnimator;
	public AudioSource bgm;
	public AudioSource[] charAudioSources; 

	private CurrentMenuAnimation currentAnimation;

	void Start() {
		currentAnimation = CurrentMenuAnimation.Cow;
		StartCoroutine(StartAnimations());
	}

	IEnumerator StartAnimations() {
		yield return new WaitForSeconds(2.0f);
		titleAnimator.SetTrigger("play");
	}

	public void nextAnimation(){
		zedoregoVespaAnimator.SetBool("play", false);
		zedoregoPlaneAnimator.SetBool("play", false);
		liliAnimator.SetBool("play", false);

		if (currentAnimation == CurrentMenuAnimation.Cow){
			getRandomZeDoRegoAnimation();
			if(currentAnimation == CurrentMenuAnimation.Vespa){
				zedoregoVespaAnimator.SetBool("play", true);
				charAudioSources[(int)currentAnimation].Play();
			}
			else if(currentAnimation == CurrentMenuAnimation.AirPlane){
				zedoregoPlaneAnimator.SetBool("play", true);
				charAudioSources[(int)currentAnimation].Play();
			}
		}
		else
		{
			currentAnimation = CurrentMenuAnimation.Cow;
			liliAnimator.SetBool("play", true);
		}
	}

	void getRandomZeDoRegoAnimation() {
		currentAnimation = (CurrentMenuAnimation)Random.Range(0,2);
	}
}
