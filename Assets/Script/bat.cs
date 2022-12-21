using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat : MonoBehaviour
{
    private bool isTimer = true;

    Animator animator;

    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.B)) {
            animator.SetTrigger("bat");
            isTimer = false;
            StartCoroutine("Timer");
        }
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Ball" && isTimer == true)
    //    {
    //        animator.SetTrigger("bat");
    //        isTimer = false;
    //        StartCoroutine("Timer");
    //    }
    //}

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1.0f);
        isTimer = true;
    }
}
