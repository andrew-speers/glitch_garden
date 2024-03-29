﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int StarCost = 100;    

    public int GetCost()
    {
        return StarCost;
    }

    public void AddToScore(int amount)
    {
        FindObjectOfType<GameState>().Deposit(amount);
    }
}
