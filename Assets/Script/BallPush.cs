using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPush : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private bool _isPush = false;               //玉が押されたかどうか

    string[] CacheJoystickNames;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //プールしたオブジェクトを再利用するため
        //押した長さを初期化
        //_pushTime = 1;
        //フラグをfalseに
        _isPush = false;
        _rigidbody.useGravity = false;
        //rigidbodyの速度をゼロに
        _rigidbody.velocity = Vector3.zero;
        //回転を初期化
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
