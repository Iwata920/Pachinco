using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatPush : MonoBehaviour
{
    [SerializeField] private int _openAngle;
    [SerializeField] private int _closeAngle;
    [SerializeField] private float _nowAngle;
    Animator animator;

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
}
