using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderBool : MonoBehaviour
{
    public bool isSlider;

    // Start is called before the first frame update
    void Start()
    {
        isSlider = false;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            isSlider = true;
        }
    }
}
