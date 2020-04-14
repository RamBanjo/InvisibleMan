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
            invis.destination = GetNextDestination();
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
