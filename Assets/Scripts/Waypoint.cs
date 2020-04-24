using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    public List<Waypoint> nextWaypointCandidates;

    public Waypoint GetNextDestination() {
        if (nextWaypointCandidates.Count == 1) return nextWaypointCandidates[0];

        int randomIndex = Random.Range(0, nextWaypointCandidates.Count);

        return nextWaypointCandidates[randomIndex];
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        InvisibleMan invis = collision.GetComponent<InvisibleMan>();

        if(invis != null) {

            //the destination will only be changed if the colliding object is an invisible man AND this destination is the intended destination
            if(invis.destination == this) {
                invis.destination = GetNextDestination();
                invis.persistentDestination = invis.destination;
            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
