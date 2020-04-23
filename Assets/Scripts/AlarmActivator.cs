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
        InvisibleMan iv = collision.GetComponent<InvisibleMan>();

        //the alarm will ring when invisible people are near and if it's not broken
        if(iv != null && !attachedAlarm.isBroken) {
            attachedAlarm.Ring(iv);
        }
    }

}
