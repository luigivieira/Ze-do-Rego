using UnityEngine;
using System.Collections;

public class DoPlayerPickObject : MonoBehaviour {

	private Player currentPlayer;
	void Start() {
		currentPlayer = GameObject.FindObjectOfType<Player>();
		currentPlayer.MoveToCollectable();
	}
	
}
