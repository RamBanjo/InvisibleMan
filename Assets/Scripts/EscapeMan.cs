using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMan : InvisibleMan {

    public Collider2D activateRadius;
    public Collider2D playerRadius;

    private void Update() {
        Movement();
    }

    new public void Movement() {

        if (activateRadius.IsTouching(playerRadius)) {
            RunAway();
        } else {
            MoveToDestination();
        }

    }

    new public void MoveToDestination() {
        if (destination == null) {
            destination = GetClosestWaypoint();
        }

        base.MoveToDestination();

    }

    private void RunAway() {
        if (destination != null) destination = null;

        Vector2 myPosition = transform.position;
        Vector2 playerLocation = playerRadius.transform.position;
        Vector2 moveDir = myPosition - playerLocation;

        int stopWhenCaught = 1;

        if (caught) {
            stopWhenCaught = 0;
        }

        transform.Translate(moveDir.normalized * speed * Time.deltaTime * stopWhenCaught);

    }

}
