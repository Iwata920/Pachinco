using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocketArea : MonoBehaviour
{
    BallGenerate _BallGenerate;

    private int _BallIncrease = 5; //�ʂ̑�����

    [SerializeField]
    private bool _isHit; //�����p���̃t���O��true�Ȃ�ʂ͑�����

    private void Start()
    {
        _BallGenerate = GameObject.Find("BallGenerator").GetComponent<BallGenerate>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            other.gameObject.SetActive(false);

            if (_isHit)
            {
                _BallGenerate.GetSetBallCount += _BallIncrease;
            }
        }
    }
}
