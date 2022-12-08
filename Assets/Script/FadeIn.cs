using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    //MeshRenderer mesh;
    SpriteRenderer spriteRenderer;
    

    void Start()
    {
        /*mesh = GetComponent<MeshRenderer>();
        mesh.material.color = mesh.material.color + new Color32(0, 0, 0, 0);
        StartCoroutine("Transparent");*/

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = spriteRenderer.color + new Color32(0, 0, 0, 0);
        StartCoroutine("Transparent");
    }

    IEnumerator Transparent()
    {
        for (int i = 255; i > 0; i--)
        {
            spriteRenderer.color = spriteRenderer.color + new Color32(0, 0, 0, 1);
            yield return new WaitForSeconds(0.025f);
        }
    }
}
