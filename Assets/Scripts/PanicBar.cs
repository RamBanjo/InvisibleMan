using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanicBar : MonoBehaviour
{

    private Slider panicBar;    
    // Start is called before the first frame update
    void Start()
    {
        panicBar = GetComponent<Slider>();
        panicBar.value = panicBar.minValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (panicBar.value < panicBar.maxValue) {
            panicBar.value += Time.deltaTime;

            if(panicBar.value >= panicBar.maxValue) {
                GameManager.panic = true;
            }
        }

        if (Input.GetKey(KeyCode.Equals)) {
            panicBar.value = 99;
        }
    }
}
