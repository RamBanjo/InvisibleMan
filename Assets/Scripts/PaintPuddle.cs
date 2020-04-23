using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintPuddle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        //if something enters collision with this gameobject, check if it's a person
        InvisibleMan invisMan = collision.GetComponent<InvisibleMan>();

        //if the person game object exists, then make them leave prints
        if (invisMan != null) {
            StartCoroutine(invisMan.StartBeingPainted());
        }
    }
}
