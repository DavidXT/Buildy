using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    private static SoundManager _instance;
    //private float fSoundVolume = 1;

    [Header("Sounds")]
    public AudioSource Music;
    public AudioSource ButtonClic;

    void Awake()
    {
        if (_instance == null)
        {

            _instance = this;
            DontDestroyOnLoad(this.gameObject);

            //Rest of your Awake code
            PlayMusic();
        }
        else
        {
            Destroy(this);
        }
    }
    
    public void PlayMusic()
    {
        Music.Play();
    }

    public void ToggleSound()
    {
        if (Music.mute)
        {
            Music.mute = false;
        }
        else
        {
            Music.mute = true;
        }
    }

    public void PlayButtonSound()
    {
        ButtonClic.Play();
    }
}
