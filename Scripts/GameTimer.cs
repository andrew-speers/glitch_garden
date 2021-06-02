using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Time in seconds")]
    [SerializeField] float levelTime = 20f;


    GameState state;    

    private void Start()
    {
        state = FindObjectOfType<GameState>();

        levelTime *= DifficultyPresets.GetTimerMod();
    }

    private void Update()
    {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        if (!state.isSpawning()) return;

        if (Time.timeSinceLevelLoad >= levelTime) state.StopSpawns();
    }
}
