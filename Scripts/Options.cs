using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Options : MonoBehaviour
{
    [SerializeField] Slider volumeSlider = null, difficultySlider = null;
    [SerializeField] float volumeDefault = 0.5f, difficultyDefault = 1f;

    [SerializeField] TextMeshProUGUI difficultyText = null;

    [TextAreaAttribute(5, 20)]
    [SerializeField] string[] difficultyExplanations = new string[3];

    private void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    private void Update()
    {
        difficultyText.text = difficultyExplanations[(int) difficultySlider.value];
    }

    public void ResetSliders()
    {
        volumeSlider.value     = volumeDefault;
        difficultySlider.value = difficultyDefault;
    }

    public void SavePrefsAndReturn()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty(difficultySlider.value);

        try
        {
            FindObjectOfType<MusicPlayer>().SetVolume(volumeSlider.value);
        } catch (System.NullReferenceException nre)
        {
            Debug.LogError(nre);
        }


        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }
}
