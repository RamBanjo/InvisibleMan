using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlourPatch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision) {
        //if something enters collision with this gameobject, check if it's a person
        Person personInstance = collision.GetComponent<Person>();

        //if the person game object exists, then make them leave prints
        if (personInstance != null) {
            StartCoroutine(personInstance.StartLeavingPrints());
        }
    }
}
