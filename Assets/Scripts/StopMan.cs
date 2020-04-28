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

        string[] masks = { "NPCs", "hazards", "activeradii" };
        int masking = LayerMask.GetMask(masks);

        Player hitPlayer = null;

        if (activateRadius.IsTouching(playerRadius)) {
            RaycastHit2D hit = Physics2D.Linecast(transform.position, playerRadius.transform.position, ~masking);
            hitPlayer = hit.collider.GetComponent<Player>();
        }

        if (hitPlayer != null && activateRadius.IsTouching(playerRadius)) {
            speed = 0;
        } else {
            speed = permanentSpeed;
        }

        MoveToDestination();

    }
}
