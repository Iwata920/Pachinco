using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accel : MonoBehaviour
{
    [SerializeField]
    private float xSpeed = 5f;
    [SerializeField]
    private float ySpeed = 5f;
    [SerializeField]
    private float zSpeed = 5f;

    private bool isAccel = true;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "yakyuu" && isAccel == true)
        {
            transform.GetComponent<Rigidbody>().velocity = new Vector3(xSpeed, ySpeed, zSpeed);
            isAccel = false;
            StartCoroutine("Time");
        }
    }
    IEnumerator Time()
    {
        yield return new WaitForSeconds(20.0f);
        isAccel = true;
    }
}
