using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    GameState state;

    private void Start()
    {
        state = FindObjectOfType<GameState>();
    }

    private void OnMouseDown()
    {
        if (defender)
        {
            SpawnDefender(GetSquareClicked());
        }
    }

    Vector2 GetSquareClicked()
    {
        Vector2 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);        
        return new Vector2(Mathf.RoundToInt(vec.x), Mathf.RoundToInt(vec.y));
    }
    
    public void SetDefender(Defender d)
    {
        defender = d;
    }

    void SpawnDefender(Vector2 spawnPos)
    {
        if (state.GetBalance() >= defender.GetCost())
        {
            state.Withdraw(defender.GetCost());
            Defender newDefender = Instantiate(
               defender,
               spawnPos,
               Quaternion.identity) as Defender;
        }
    }
}
