using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class SEManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] audioClips;

    AudioSource SEaudioSource;
   

    private void Start()
    {
        SEaudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "TitleScene":
                break;
            case "Main":
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SEplay(0);
                }
                break;
        }
        
    }

    public void SEplay(int number)
    {
        SEaudioSource.PlayOneShot(audioClips[number]);
    }
}
