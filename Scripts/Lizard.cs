using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    Attacker attacker;
    private void Start()
    {
        attacker = GetComponent<Attacker>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Defender>()) attacker.Attack(collision.gameObject);
    }
}
