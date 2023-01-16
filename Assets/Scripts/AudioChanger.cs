using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioChanger : MonoBehaviour
{
    public AudioSource menuSong;
    public AudioSource slideSong;
    void Start()
    {
        menuSong.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSlideSong() {
        if (menuSong.isPlaying)
        menuSong.Stop();
        slideSong.Play();
    }
}
