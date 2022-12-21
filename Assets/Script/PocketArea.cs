using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocketArea : MonoBehaviour
{
    BallGenerate _BallGenerate;

    private int _BallIncrease = 5; //‹Ê‚Ì‘‰Á—Ê
    SEManager seManager;

    [SerializeField]
    private bool _isHit; //ÀŒ±—p‚±‚Ìƒtƒ‰ƒO‚ªtrue‚È‚ç‹Ê‚Í‘‚¦‚é

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
                //•Û—¯‚ª“ü‚Á‚½‚Ì‰¹
                seManager.SEplay(2);
                _BallGenerate.GetSetBallCount += _BallIncrease;
            }
        }
    }
}
