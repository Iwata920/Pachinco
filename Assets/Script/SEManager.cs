using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SEplay(0);
        }
    }

    public void SEplay(int number)
    {
        SEaudioSource.PlayOneShot(audioClips[number]);
    }

}
