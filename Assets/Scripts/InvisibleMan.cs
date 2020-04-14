using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleMan : Person
{

    //list of points in the map that the invisible person will move. this should loop in some way, for now.
    public List<Transform> waypoints;

    //the point where the invisible man should walk to. once the invisible man arrives at that point, he will get a new random destination from the waypoint's "next waypoints".
    public Waypoint destination;

    //make the invisible person move from waypoint to waypoint.
    //if the invisible man isn't at the waypoint, make them move towards destination point.
    //when arriving at the waypoint, the waypoint will change the invisible man and give them a new destination.
    //make sure consecutive waypoints aren't blocked by walls.

    private void Update() {
        transform.position = Vector2.MoveTowards(transform.position, destination.transform.position, Time.deltaTime * speed);
    }
}
