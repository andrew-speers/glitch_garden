using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master volume", DIFFICULTY_KEY = "difficulty";

    const float MIN_VOLUME = 0f, MAX_VOLUME = 1f, MIN_DIFF = 0f, MAX_DIFF = 2f;    

    public static void SetMasterVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else Debug.LogError("Volume out of range");
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

    public static void SetDifficulty(float diff)
    {
        if (diff >= MIN_DIFF && diff <= MAX_DIFF)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, diff);
        }
        else Debug.LogError("Difficulty out of range");
    }
}
