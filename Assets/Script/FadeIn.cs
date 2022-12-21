using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    //MeshRenderer mesh;
    SpriteRenderer spriteRenderer;
    LightEffect lightEffect;
    private bool _isTransition;
    TitleFade titleFade;
    [SerializeField] GameObject title;
    [SerializeField] GameObject camera;
    [SerializeField] GameObject text;
    SEManager seManager;
    BgmManager bgmManager; 


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = spriteRenderer.color + new Color32(0, 0, 0, 0);
        StartCoroutine("Transparent");
        titleFade = title.GetComponent<TitleFade>();
        lightEffect = camera.GetComponent<LightEffect>();
        seManager = GameObject.FindGameObjectWithTag("SE").GetComponent<SEManager>();
        bgmManager = GameObject.FindGameObjectWithTag("Bgm").GetComponent<BgmManager>();
    }

    private void Update()
    {
        // タイトルのアニメーションが終わったらボタンを有効化
        if(_isTransition && Input.anyKey)
        {
            seManager.SEplay(0);
            bgmManager.StopBgm();
            lightEffect.setBool(true);
            titleFade.StartCoroutine("StartFadeOut");
            _isTransition = false;
        }
    }


    IEnumerator Transparent()
    {
        for (int i = 255; i > 0; i--)
        {
            spriteRenderer.color = spriteRenderer.color + new Color32(0, 0, 0, 1);
            yield return new WaitForSeconds(0.025f);
        }
        _isTransition = true;
        text.SetActive(true);
    }
}
