using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private float defaultMusicVolume = 0.5f; // Set your default volume here
    private float defaultSFXVolume = 0.5f;   // Set your default volume here

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            // Load volume settings from PlayerPrefs
            LoadVolumeSettings();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("MainMenumusic");
    }

    private void LoadVolumeSettings()
    {
        // Load music volume from PlayerPrefs, use default if not set
        musicSource.volume = PlayerPrefs.GetFloat("MusicVolume", defaultMusicVolume);

        // Load SFX volume from PlayerPrefs, use default if not set
        sfxSource.volume = PlayerPrefs.GetFloat("SFXVolume", defaultSFXVolume);
    }

    private void SaveVolumeSettings()
    {
        // Save current music and SFX volume to PlayerPrefs
        PlayerPrefs.SetFloat("MusicVolume", musicSource.volume);
        PlayerPrefs.SetFloat("SFXVolume", sfxSource.volume);
        PlayerPrefs.Save();
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
            Debug.Log("Playing SFX: " + s.name);
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
        Debug.Log("SFX Mute state: " + sfxSource.mute);
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
        SaveVolumeSettings(); // Save volume settings when changed
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
        SaveVolumeSettings(); // Save volume settings when changed
        Debug.Log("SFX Volume set to: " + volume);
    }

    private void OnDestroy()
    {
        SaveVolumeSettings(); // Save volume settings before destroying
    }
}
