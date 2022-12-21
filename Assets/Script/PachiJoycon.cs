using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum LorR
{
    Left,
    Right
}

public class PachiJoycon : MonoBehaviour
{
    [SerializeField]
    LorR joyconType;
    List<Joycon> joycons;
    Joycon joycon;
    private float _pushPower;
    private bool _isStop;
    void Start()
    {
       
        joycons = JoyconManager.Instance.j;
        switch (joyconType)
        {
            case LorR.Left:
                joycon = joycons.Find(c => c.isLeft);
                break;
            case LorR.Right:
                joycon = joycons.Find(c => !c.isLeft);
                break;
        }

        StartCoroutine("StopShot");
    }

    private void Update()
    {
        if (_isStop)
        {
            _pushPower = (Quaternion.ToEulerAngles(joycon.GetVector()).y / Mathf.PI * 180 * (-1) + 180) / 180;
            if(_pushPower > 1)
            {
                _pushPower = 1;
            }
        }
        
        Debug.Log(_pushPower);
    }

    public float GetSetPower
    {
        get { return _pushPower; }
        set { _pushPower = value; }
    }

    IEnumerator StopShot()
    {
        yield return new WaitForSeconds(1);
        _isStop = true;
    }
}
