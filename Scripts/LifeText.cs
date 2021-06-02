using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeText : MonoBehaviour
{
    TextMeshProUGUI text;
    GameState state;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        state = FindObjectOfType<GameState>();
    }

    private void Update()
    {
        text.text = state.GetLife().ToString();
    }
}
