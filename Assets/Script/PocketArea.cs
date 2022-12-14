using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocketArea : MonoBehaviour
{
    BallGenerate _BallGenerate;

    private int _BallIncrease = 5; //玉の増加量
    SEManager seManager;

    [SerializeField]
    private bool _isHit; //実験用このフラグがtrueなら玉は増える

    private void Start()
    {
        seManager = GameObject.FindGameObjectWithTag("SE").GetComponent<SEManager>();
        _BallGenerate = GameObject.Find("BallGenerator").GetComponent<BallGenerate>();
        Debug.Log(this.gameObject.tag);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            other.gameObject.SetActive(false);

            //if (_isHit)
            //{
            //    _BallGenerate.GetSetBallCount += _BallIncrease;
            //}

            if(this.gameObject.tag == "startchucker")
            {
                //保留が入った時の音
                seManager.SEplay(2);
                _BallGenerate.GetSetBallCount += _BallIncrease;
            }
        }
    }
}
