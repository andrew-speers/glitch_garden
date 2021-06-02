using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;

    private void Start()
    {
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();

        audioSource.volume = PlayerPrefsController.GetMasterVolume();

        this.transform.position = Camera.main.transform.position;
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
