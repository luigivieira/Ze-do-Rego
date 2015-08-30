using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {
	[System.Serializable]
	public class WaypointLink {
		public Waypoint waypoint;
		public int distance;
	}

	public WaypointLink [] nextWaypoints;

	void OnDrawGizmosSelected(){
		foreach( var go in nextWaypoints){
			if (go != null && go.waypoint != null){
				Gizmos.DrawLine(transform.position, go.waypoint.transform.position);
			}
		}
	}
	void OnDrawGizmos() {
		Gizmos.DrawSphere(transform.position,0.5f);
	}

}
