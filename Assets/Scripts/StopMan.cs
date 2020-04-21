using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMan : InvisibleMan {

    public Collider2D activateRadius;
    private float permanentSpeed;
    public Collider2D playerRadius;

    private void Start() {
        permanentSpeed = speed;
    }

    private void Update() {
        Movement();
    }

    new public void Movement() {

        if (activateRadius.IsTouching(playerRadius)) {
            speed = 0;
        } else {
            speed = permanentSpeed;
        }

        MoveToDestination();

    }
}
