using UnityEngine;
using System.Collections;

public class FindPath : Singleton<FindPath> {

	// Use this for initialization
	private Waypoint [] waypointList;
	private Waypoint destination;
	void Init () {
		waypointList = FindObjectsOfType<Waypoint>();
	}
	
	public Waypoint GetCurrentWaypoint(Vector3 pos) {
		if (waypointList == null){
			Init ();
		}
		float minorDistance = 999999f;
		Waypoint selectedWaypoint = null;
		foreach (var wp in waypointList){
			float curDist = Vector3.Distance(pos, wp.transform.position);
			if (curDist < minorDistance){
				minorDistance = curDist;
				selectedWaypoint = wp;
			}
		}
		return selectedWaypoint;
	}

	public void SetDestination(Vector3 pos) {
		if (waypointList == null){
			Init ();
		}
		destination = GetCurrentWaypoint(pos);
		Debug.Log("Destination set to " + pos.ToString());
	}

	public void ClearDestination(){
		destination = null;
	}

	public bool HasDestination(){
		return destination != null;
	}

	public Waypoint DoStep(Waypoint from){
		if (destination == null){
			return null;
		}
		if (from.GetInstanceID() == destination.GetInstanceID()){
			destination = null;
			return from;
		}
		if (waypointList == null){
			Init ();
		}
		float totalDistance = Vector3.Distance(from.transform.position, destination.transform.position);
		float minorDistance = totalDistance;
		Waypoint selectedWaypoint = null;
		foreach (var wp in from.nextWaypoints){
			float curDist = Vector3.Distance(wp.waypoint.transform.position, destination.transform.position);
			if (curDist < minorDistance){
				minorDistance = curDist;
				selectedWaypoint = wp.waypoint;
			}
		}
		return selectedWaypoint;
	}

}
