using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{

    public float duration;
    private SpriteRenderer sprite;


    // Start is called before the first frame update
    void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
