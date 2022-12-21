using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atarime : MonoBehaviour
{
    private bool isFall;
    private GameObject Obj;

    private void Start()
    {
        isFall = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Obj = other.gameObject;
            isFall = true;
        }
    }

    private void Update()
    {
        if(isFall)
        {
            Obj.SetActive(false);
            isFall = false;
        }
    }
}
