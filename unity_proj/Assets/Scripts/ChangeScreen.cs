using UnityEngine;
using System.Collections;

public class ChangeScreen : MonoBehaviour {

	public void DoLoadLevel(string name) {
		Application.LoadLevel(name);
	}
}
