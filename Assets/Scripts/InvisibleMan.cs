using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleMan : Person
{

    //list of points in the map that the invisible person will move. this should loop in some way, for now.
    public List<Transform> waypoints;

    //queue of points the invisible man should walk to. when the invisible person arrives at the waypoint, pop the first member and move to the next one.
    private List<Transform> travelList;

    //make the invisible person move from waypoint to waypoint.
    //if the invisible man isn't at the waypoint, make them move towards the waypoint at the first point in the waylist.
    //if the invisible man is at the waypoint, remove the waypoint from travelList.
    //make sure consecutive waypoints aren't blocked by walls.
    private void Update() {
        
    }
}
