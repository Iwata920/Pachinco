using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialTest : MonoBehaviour
{
    
    private float a;

    [SerializeField]
    Material m;

    

    private void Update()
    {
        a = a + 0.001f;

       

       m.mainTextureOffset = new Vector2(a, 3);
        Debug.Log(a);
    }
}
