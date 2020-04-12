using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{

    public GameObject footprintTemplate;
    public bool leavesPrints;
    public bool isPainted;

    //variables that has to do with spawning footprints
    //flourdistance: how long a person has to walk before they stop leaving footprints
    //flourinterval: how long a person has to walk until a set of prints is spawned
    //distanceUntilSpawnFlour: distance until the next set of prints is spawned, internal-use only
    public float flourDistance;
    public float flourInterval;
    private float distanceUntilSpawnFlour;

    public float afflictionDuration;
    public float afflictionInterval;

    // Start is called before the first frame update
    void Start()
    {
        distanceUntilSpawnFlour = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if a person leaves prints
    }

    public IEnumerator StartLeavingPrints() {

        //start leaving prints
        leavesPrints = true;

        //while this character should leave prints...
        while (leavesPrints) {

            //set the distance until spawning prints to be the distance interval of spawning prints
            distanceUntilSpawnFlour = flourInterval;

            //set here to be the start position
            Vector2 startPos = transform.position;

            //while the distance to next flour is greater than 0...
            while (distanceUntilSpawnFlour > 0) {
                
                //set here to be current position
                Vector2 currentPos = transform.position;

                //distance calculated from start to here
                float distanceTravelled = Vector2.Distance(startPos, currentPos);

                //subtract from spawn interval and total flour distance
                distanceUntilSpawnFlour -= distanceTravelled;
                flourDistance -= distanceTravelled;

                //set here to be the new start point
                startPos = transform.position;

                //wait for a bit before re-calculating location
                yield return new WaitForSeconds(0.1f);
            }

            //when distance is zero or less, spawn some prints
            GameObject newPrints = Instantiate(footprintTemplate, transform.position, transform.rotation);

            //if player has walked far enough, no longer leave any prints
            if(flourDistance <= 0) {
                leavesPrints = false;
            }

        }
    }


    //might make this code work with paint instead, don't delete this yet
    //-- banjo
    /*
    IEnumerator StartLeavingPrints() {
        //this method should be called from the flour puddle
        leavesPrints = true;
        StartCoroutine(LeavePrints());
        yield return new WaitForSeconds(afflictionDuration);
        leavesPrints = false;
    }

    IEnumerator LeavePrints() {
        while (leavesPrints) {
            GameObject newPrints = Instantiate(footprintTemplate, transform.position, transform.rotation);
            yield return new WaitForSeconds(afflictionInterval);
        }
    }*/



}
