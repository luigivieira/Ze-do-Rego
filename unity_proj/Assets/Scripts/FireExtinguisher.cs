using UnityEngine;
using System.Collections;
using Fungus;

public class FireExtinguisher : Interactable {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Observe() {
		Say("ObserveFireExtinguisher");
	}
}
