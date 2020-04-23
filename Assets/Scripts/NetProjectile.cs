using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetProjectile : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody2D rb2d;

    public float speed;

    public delegate void EnemyCaptured();
    public static event EnemyCaptured EnemyCapturedDelegate;

    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        InvisibleMan target = collision.collider.GetComponent<InvisibleMan>();

        if(target != null) {
            rb2d.velocity = Vector2.zero;
            target.caught = true;
            collision.collider.attachedRigidbody.velocity = Vector2.zero;
            target.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
            EnemyCapturedDelegate();
        }

        Player p = collision.collider.GetComponent<Player>();

        if (p == null) {
            Instantiate(GameManager.s_gamePickups[1], transform.position, transform.rotation);
            Destroy(gameObject);
        }



    }
}
