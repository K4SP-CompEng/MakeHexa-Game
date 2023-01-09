using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] public Sound[] music;
    [SerializeField] public AudioSource musicSource;
    // Start is called before the first frame update
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("Background Music");
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(music, x => x.name == name);
        if (s == null) Debug.Log("Sound Not Found");
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }
    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
}
