using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public GameManager.Items itemType;
    public Sprite unselected;
    public Sprite selected;
    private SpriteRenderer mySprite;

    private void Awake() {
        mySprite = this.GetComponent<SpriteRenderer>();
        mySprite.sprite = unselected;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Player playerInstance = collision.GetComponent<Player>();

        if (playerInstance != null) {
            mySprite.sprite = selected;
            playerInstance.hovering = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        Player playerInstance = collision.GetComponent<Player>();

        if (playerInstance != null) {
            mySprite.sprite = unselected;
            playerInstance.hovering = null;
        }
    }

}
