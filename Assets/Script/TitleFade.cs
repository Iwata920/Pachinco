using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleFade : MonoBehaviour
{
    [SerializeField] private float _fadeSpeed;

    private GameObject fadeInObj;
    private GameObject fadeOutObj;
    [SerializeField] Image fadeInImage;
    [SerializeField] Image fadeOutImage;
    [SerializeField] GameObject TitleObj;
    [SerializeField] GameObject DemoObj;
    FadeManager fadeManager;

    private void Start()
    {
        fadeInObj = GameObject.FindGameObjectWithTag("FadeIN");
        fadeOutObj = GameObject.FindGameObjectWithTag("FadeOut");
        fadeInImage = fadeInObj.GetComponent<Image>();
        fadeManager = GetComponent<FadeManager>();
    }

    public IEnumerator StartFadeOut()
    {
        // タイトル画面のフェイドアウト
        for (int i = 255; i > 0; i--)
        {
            fadeInImage.color = fadeInImage.color + new Color32(0, 0, 0, 1);
            yield return new WaitForSeconds(_fadeSpeed / 2);
        }

        // 警告画面を表示
        TitleObj.SetActive(false);
        DemoObj.SetActive(true);

        // フェイドアウトしメインシーンへ遷移
        for (int i = 255; i > 0; i--)
        {
            fadeInImage.color = fadeInImage.color - new Color32(0, 0, 0, 1);
            yield return new WaitForSeconds(_fadeSpeed / 2.5f);
        }

        yield return new WaitForSeconds(2.5f);
        fadeManager.LoadScene("Main", 1.0f);

    }

}
