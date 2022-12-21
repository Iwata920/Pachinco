using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveBool : MonoBehaviour
{
    public bool isCurve;

    // Start is called before the first frame update
    void Start()
    {
        isCurve = false;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            isCurve = true;
        }
    }
}
