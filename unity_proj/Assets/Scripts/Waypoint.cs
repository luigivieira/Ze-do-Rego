using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {
	public GameObject [] nextWaypoints;
	public int weight = -1;
	void OnDrawGizmosSelected(){
		foreach( var go in nextWaypoints){
			Gizmos.DrawLine(transform.position, go.transform.position);
		}
	}
	void OnDrawGizmos() {
		Gizmos.DrawSphere(transform.position,0.1f);
	}

}
