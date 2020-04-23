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

    //the colors on invisible men when they get painted
    public Color normalColor = Color.clear;
    public Color paintedColor = Color.green;
    public Color caughtColor = Color.white;

    //make the invisible person move from waypoint to waypoint.
    //if the invisible man isn't at the waypoint, make them move towards destination point.
    //when arriving at the waypoint, the waypoint will give them a new destination, choosing randomly from potential candidates
    //make sure consecutive waypoints aren't blocked by walls.

    private SpriteRenderer mySprite;

    protected void Start() {
        mySprite = GetComponent<SpriteRenderer>();
        mySprite.color = normalColor;
        persistentDestination = destination;
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
            mySprite.color = caughtColor;
            GameManager.Lose();
        }
    }

    public IEnumerator StartBeingPainted() {
        //this method should be called from the paint puddle
        afflictionTimer = afflictionDuration;
        mySprite.color = paintedColor;

        if (!isPainted) {
            isPainted = true;

            while (afflictionTimer > 0) {
                mySprite.color = Color.Lerp(normalColor, paintedColor, afflictionTimer / afflictionDuration * 4);

                afflictionTimer -= Time.deltaTime;

                yield return new WaitForSeconds(0);

                if (caught) {
                    break;
                }
            }

            if (!caught) {
                mySprite.color = normalColor;
            }

            isPainted = false;
        }
    }


}
