using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmPoint : Waypoint
{
    public Collider2D detectionRange;
    public AudioSource alarmSound;
    public AudioSource breakSound;
    public Sprite brokenSprite;
    [HideInInspector]
    public bool isBroken;

    private List<InvisibleMan> peopleChasingThisAlarm;
    private SpriteRenderer mySprite;

    // Start is called before the first frame update
    void Start()
    {
        isBroken = false;
        mySprite = GetComponent<SpriteRenderer>();
        peopleChasingThisAlarm = new List<InvisibleMan>();
    }

    public void Ring(InvisibleMan target) {
        //if the alarm isn't already sounding, it will ring
        if (!alarmSound.isPlaying) {
            alarmSound.Play();
        }

        //make the target invisible man chase the alarm
        target.destination = this;

        //make a list of who's chasing the alarm so we can send them back to their own tracks later
        peopleChasingThisAlarm.Add(target);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //when touched by an invisible person, this alarm will brea

        InvisibleMan iv = collision.GetComponent<InvisibleMan>();

        //the alarm will ring when invisible people are near and if it's not broken
        if (iv != null && !isBroken) {
            isBroken = true;
            alarmSound.Stop();
            breakSound.Play();
            mySprite.sprite = brokenSprite;
            foreach(InvisibleMan man in peopleChasingThisAlarm) {
                man.destination = man.persistentDestination;
            }
        }
    }

}
