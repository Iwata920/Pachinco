using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatPush : MonoBehaviour
{
    [SerializeField] private int _openAngle;
    [SerializeField] private int _closeAngle;
    [SerializeField] private float _nowAngle;
    Animator animator;

    private bool _isOpen;
    private bool _isClose;


    private void Start()
    {
        transform.rotation = Quaternion.Euler(0f, _closeAngle, 90f);
        _nowAngle = _closeAngle;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isSwing", true);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine("CloseBat");
        }
    }

    IEnumerator OpenBat()
    {
        for (int turn = 0; turn < _openAngle; turn++)
        {
            transform.Rotate(-1, 0, 0);
            yield return new WaitForSeconds(0.0001f);
        }
    }

    IEnumerator CloseBat()
    {
        for (int turn = 0; turn < _closeAngle; turn++)
        {
            transform.Rotate(1, 0, 0);
            yield return new WaitForSeconds(0.0001f);
        }
    }



    //[SerializeField] private float spring;
    //[SerializeField] private float damper;
    //[SerializeField] private float openAngle;
    //[SerializeField] private float closeAngle;

    //HingeJoint hingeJoint;
    //JointSpring jointSpring;

    //void Start()
    //{
    //    hingeJoint = GetComponent<HingeJoint>();
    //    jointSpring = hingeJoint.spring;
    //    jointSpring.targetPosition = closeAngle;
    //    closeBat();
    //}

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        openBat();
    //    }

    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        closeBat();
    //    }
    //}
    //public void openBat()
    //{
    //    jointSpring.spring = spring;
    //    jointSpring.damper = damper;
    //    jointSpring.targetPosition = openAngle;
    //    hingeJoint.spring = jointSpring;
    //}

    //public void closeBat()
    //{
    //    jointSpring.spring = spring;
    //    jointSpring.damper = damper;
    //    jointSpring.targetPosition = closeAngle;
    //    hingeJoint.spring = jointSpring;
    //}
}
