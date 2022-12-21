using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingBall : MonoBehaviour
{
    [SerializeField]
    private GameObject Slider;
    [SerializeField]
    private GameObject Curve;

    private float zSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Slider.GetComponent<SliderBool>().isSlider)
        {
            zSpeed = Random.Range(3.0f, 4.0f);
        }
        else if (Curve.GetComponent<CurveBool>().isCurve)
        {
            zSpeed = Random.Range(-2.7f, -3.2f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 sliderDirection = new Vector3(0, 0, zSpeed);
            rb.AddForce(sliderDirection * 1);
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
