using UnityEngine;
using System.Collections;

public class DismissBalloon : MonoBehaviour {
	public float timeout = 5.0f;
	void Start () {
		Invoke("Dismiss",timeout);
	}
	void Dismiss() {
		this.gameObject.SetActive(false);
	}
}
