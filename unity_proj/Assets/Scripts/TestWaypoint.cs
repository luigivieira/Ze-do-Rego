using UnityEngine;
using System.Collections;

public class TestWaypoint : MonoBehaviour {

	public void Test(){
		FindPath.Instance().SetDestination(new Vector3(-18,-6));
		Waypoint next = FindPath.Instance().DoStep(FindPath.Instance().GetCurrentWaypoint(this.transform.position));
		Debug.Log(next.gameObject);
		transform.position = next.transform.position;
	}
}
