using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingMan : InvisibleMan {

    public Collider2D activateRadius;
    public Collider2D playerRadius;

    private void Update() {
        Movement();
    }

    new public void Movement() {

        /*Player hitPlayer = null;

        if (activateRadius.IsTouching(playerRadius)) {
            hitPlayer = Physics2D.Linecast(transform.position, playerRadius.transform.position).collider.GetComponent<Player>();
        }*/

        if (/*hitPlayer != null*/ activateRadius.IsTouching(playerRadius)) {
            MoveToPlayer();
        } else {
            MoveToDestination();
        }

    }

    new public void MoveToDestination() {
        if(destination == null) {
            destination = persistentDestination;
        }

        base.MoveToDestination();
        
    }

    private void MoveToPlayer() {
        if(destination != null) destination = null;

        Vector2 myPosition = transform.position;
        Vector2 myDestination = playerRadius.transform.position;

        int stopWhenCaught = 1;

        if (caught) {
            stopWhenCaught = 0;
        }

        transform.position = Vector2.MoveTowards(myPosition, myDestination, Time.deltaTime * speed * stopWhenCaught);

    }
}
