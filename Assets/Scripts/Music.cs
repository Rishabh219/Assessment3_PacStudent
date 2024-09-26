using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip introMusic;
    public AudioClip ghostNormalMusic;

    // Start is called before the first frame update
    void Start()
    {
        // Plays intro music
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // Plays ghost normal state music
        if (!audioSource.isPlaying)
        {
            audioSource.clip = ghostNormalMusic;
            audioSource.Play();
        }
    }
}
