using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleMan : Person
{

    //the point where the invisible man should walk to. once the invisible man arrives at that point, he will get a new random destination from the waypoint's "next waypoints".
    //you need to set an initial point on the map otherwise it will not work.
    public Waypoint destination;
    public Waypoint persistentDestination;

    //by default, an invisible man isn't caught. if he is caught, then this is set to true and he stops moving.
    public bool caught = false;

    //how many seconds the invisible person should wait before changing the destination.

    //make the invisible person move from waypoint to waypoint.
    //if the invisible man isn't at the waypoint, make them move towards destination point.
    //when arriving at the waypoint, the waypoint will give them a new destination, choosing randomly from potential candidates
    //make sure consecutive waypoints aren't blocked by walls.

    private Collider2D myCollider;
    private Collider2D destinationCollider;

    private void Start() {

    }

    private void Update() {
        Movement();
    }

    public void Movement() {
        MoveToDestination();
    }

    public void MoveToDestination() {
        Vector2 myPosition = transform.position;
        Vector2 myDestination = destination.transform.position;

        int stopWhenCaught = 1;

        if (caught) {
            stopWhenCaught = 0;
        }

        transform.position = Vector2.MoveTowards(myPosition, myDestination, Time.deltaTime * speed * stopWhenCaught);
    }

    protected Waypoint GetClosestWaypoint() {
        Waypoint minWP = null;
        float minDist = Mathf.Infinity;
        Vector2 currentPos = transform.position;

        foreach (Waypoint wp in GameManager.allWayPoints) {
            float distance = Vector2.Distance(wp.transform.position, currentPos);
            if (distance < minDist) {
                minWP = wp;
                minDist = distance;
            }
        }
        return minWP;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Player player = collision.collider.GetComponent<Player>();

        if(player != null && GameManager.panic && !caught) {
            player.speed = 0;
            this.GetComponent<SpriteRenderer>().color = Color.white;
            GameManager.Lose();
        }
    }
}
