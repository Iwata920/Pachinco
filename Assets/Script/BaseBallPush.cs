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
        //スペースを離したら発射
        if (Input.GetKey(KeyCode.Space))
        {
            //フラグがfalseの時のみ力を加える
            if (!_isPush)
            {
                //ここでフラグをtrueにすることで一度動いた玉を物理演算に任せる
                _isPush = true;
                //重力を使えるようにする
                _rigidbody.useGravity = true;
                //玉の速度*ボタンを押した長さ*上方向のベクトル
                _rigidbody.AddForce(_ballSpeed * Vector3.back, ForceMode.Force);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //プールしたオブジェクトを再利用するため
        //押した長さを初期化
        _pushTime = 1;
        //フラグをfalseに
        _isPush = false;
        _rigidbody.useGravity = false;
        //rigidbodyの速度をゼロに
        _rigidbody.velocity = Vector3.zero;
        //回転を初期化
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
