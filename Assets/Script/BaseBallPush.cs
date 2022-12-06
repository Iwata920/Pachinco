using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBallPush : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField]
    private float _ballSpeed;                   //玉のスピード
    [SerializeField]
    private float _pushPower = 0.01f;           //ボタンを押している間にpushTimeに加算される値
    private float _pushTime = 1;                //押している長さによって玉の速度が変わる

    private bool _isPush = false;               //玉が押されたかどうか

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(!_isPush)
        {
            _rigidbody.AddForce(_ballSpeed * Vector3.back, ForceMode.Force);
            _isPush = true;
        }
        
    }

   
}
