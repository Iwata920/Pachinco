using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;//必要
using UnityEngine.Rendering.Universal;//必要;

public class LightEffect : MonoBehaviour
{
    [SerializeField]
    Volume m_Volume;

    bool isDown = false;
    private bool isStop;

    
    void Update()
    {
        Bloom c;
        m_Volume.profile.TryGet(out c);

        if (!isStop)
        {
            if (c.intensity.value < 7 && !isDown)
            {
                c.intensity.value += 2 * Time.deltaTime;
            }
            else if (isDown)
            {
                c.intensity.value -= 2 * Time.deltaTime;
            }

            if (c.intensity.value > 7)
            {
                isDown = true;
            }
            else if (c.intensity.value <= 1.5f)
            {
                isDown = false;
            }
        } 
        else
        {
            c.intensity.value = 0;
        }
    }      

    public void setBool(bool value)
    {
        this.isStop = value;
    }
}