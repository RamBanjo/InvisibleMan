using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    [Tooltip("Duration of how long footsteps should stay on the screen in seconds.")]
    public float duration;
    private float timer;
    private SpriteRenderer sprite;


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        
        timer = duration;
    }

    // Update is called once per frame
    void Update()
    {

        sprite.color = Color.Lerp(Color.clear, Color.white, (timer / duration) * 8);

        timer -= Time.deltaTime;

        if(timer <= 0) {
            Destroy(this.gameObject);
        }
    }
}
