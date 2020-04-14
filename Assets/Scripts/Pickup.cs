using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public GameManager.Items itemType;
    public SpriteRenderer spriteOutline;

    private void OnTriggerEnter2D(Collider2D collision) {
        Player playerInstance = collision.GetComponent<Player>();

        if (playerInstance != null) {
            spriteOutline.color = Color.red;
            playerInstance.hovering = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        Player playerInstance = collision.GetComponent<Player>();

        if (playerInstance != null) {
            spriteOutline.color = Color.black;
            playerInstance.hovering = null;
        }
    }

}
