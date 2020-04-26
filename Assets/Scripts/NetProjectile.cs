using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetProjectile : MonoBehaviour
{

    private bool alreadyHit;

    private Rigidbody2D rb2d;

    public float speed;

    public delegate void EnemyCaptured();
    public static event EnemyCaptured EnemyCapturedDelegate;

    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        alreadyHit = false;
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        InvisibleMan target = collision.collider.GetComponent<InvisibleMan>();

        if(target != null) {
            rb2d.velocity = Vector2.zero;
            target.caught = true;
            collision.collider.attachedRigidbody.velocity = Vector2.zero;
            target.GetComponent<SpriteRenderer>().color = target.caughtColor;
            EnemyCapturedDelegate();
        }

        if (!alreadyHit) {
            Instantiate(GameManager.s_gamePickups[1], transform.position, transform.rotation);
        }

        alreadyHit = true;

        Destroy(gameObject);

    }
}
