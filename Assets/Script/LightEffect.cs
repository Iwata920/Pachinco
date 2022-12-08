using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LightEffect : MonoBehaviour
{
    
   // int maxLight = 30;
   // int minLight = 15;
    float LightUp = 15;

    
    Bloom bloom;

    bool isDown = false;

    // Åuusing UnityEngine.PostProcessingÅvÇÃí«â¡ÇñYÇÍÇ∏Ç…
    void Start()
    {
        bloom = ScriptableObject.CreateInstance<Bloom>();

        /*
        var behaviour = GetComponent<PostProcessProfile>();

        var Settings = behaviour.settings;
        */
    }

    // Update is called once per frame
    void Update()
    {
        bloom.enabled.Override(true);

        bloom.intensity.Override((int)LightUp);
        PostProcessManager.instance.QuickVolume(gameObject.layer, 1, bloom);

        Debug.Log(LightUp);

        if (LightUp < 30 && !isDown)
        {
            LightUp += 10 * Time.deltaTime;
        }
        else if (isDown)
        {
            LightUp -= 10 * Time.deltaTime;
        }

        if (LightUp > 30)
        {
            isDown = true;
        }

        if (LightUp <= 15)
        {
            isDown = false;
        }

        Debug.Log(LightUp);

     
    }      
}