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
        //�X�y�[�X�𗣂����甭��
        if (Input.GetKey(KeyCode.Space))
        {
            //�t���O��false�̎��̂ݗ͂�������
            if (!_isPush)
            {
                //�����Ńt���O��true�ɂ��邱�Ƃň�x�������ʂ𕨗����Z�ɔC����
                _isPush = true;
                //�d�͂��g����悤�ɂ���
                _rigidbody.useGravity = true;
                //�ʂ̑��x*�{�^��������������*������̃x�N�g��
                _rigidbody.AddForce(_ballSpeed * Vector3.back, ForceMode.Force);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //�v�[�������I�u�W�F�N�g���ė��p���邽��
        //������������������
        _pushTime = 1;
        //�t���O��false��
        _isPush = false;
        _rigidbody.useGravity = false;
        //rigidbody�̑��x���[����
        _rigidbody.velocity = Vector3.zero;
        //��]��������
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
