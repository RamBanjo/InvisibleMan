using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Person
{

    public Camera main_camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //movement, get axis
        float vert = Input.GetAxis("Vertical") * speed;
        float horz = Input.GetAxis("Horizontal") * speed;

        vert *= Time.deltaTime;
        horz *= Time.deltaTime;

        //and then move the character
        transform.Translate(horz, vert, 0);
    }
}
