using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBallPush : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField]
    private float _ballSpeed;                   //�ʂ̃X�s�[�h
    [SerializeField]
    private float _pushPower = 0.01f;           //�{�^���������Ă���Ԃ�pushTime�ɉ��Z�����l
    private float _pushTime = 1;                //�����Ă��钷���ɂ���ċʂ̑��x���ς��

    private bool _isPush = false;               //�ʂ������ꂽ���ǂ���

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
