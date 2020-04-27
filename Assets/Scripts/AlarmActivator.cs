using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmActivator : MonoBehaviour
{

    private AlarmPoint attachedAlarm;

    private void Start() {
        attachedAlarm = GetComponentInParent<AlarmPoint>();
    }

    private void OnTriggerStay2D(Collider2D collision) {

        string[] masks = { "hazards", "activeradii" };
        int masking = LayerMask.GetMask(masks);
        //print(masking + " " + ~masking);
        //masking = ~masking;

        //print(LayerMask.NameToLayer("hazards") + " " + LayerMask.NameToLayer("activeradii"));

        RaycastHit2D hit = Physics2D.Linecast(transform.position, collision.transform.position, ~masking);
        //print(hit.collider);
        //print(hit.transform.position);
        InvisibleMan iv = hit.collider.GetComponent<InvisibleMan>();

        //the alarm will ring when invisible people are near and if it's not broken
        if (iv != null && !attachedAlarm.isBroken) {
            attachedAlarm.Ring(iv);
        }
    }

}
