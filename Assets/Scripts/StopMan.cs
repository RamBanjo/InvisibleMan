using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMan : InvisibleMan {

    public Collider2D activateRadius;
    private float permanentSpeed;
    public Collider2D playerRadius;

    new private void Start() {
        base.Start();
        permanentSpeed = speed;
    }

    private void Update() {
        Movement();
    }

    new public void Movement() {

        /*Player hitPlayer = null;

        if (activateRadius.IsTouching(playerRadius)) {
            hitPlayer = Physics2D.Linecast(transform.position, playerRadius.transform.position).collider.GetComponent<Player>();
        }*/

        if (/*hitPlayer != null*/ activateRadius.IsTouching(playerRadius)) {
            speed = 0;
        } else {
            speed = permanentSpeed;
        }

        MoveToDestination();

    }
}
