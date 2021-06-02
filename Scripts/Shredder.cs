using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    [SerializeField] bool isDamageCollider = false;

    GameState state;

    private void Start()
    {
        state = FindObjectOfType<GameState>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //StartCoroutine(state.LoseLife(1));
        if (isDamageCollider) state.LoseLife(1);
        Destroy(collision.gameObject);
    }
}
