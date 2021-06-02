using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    Animator anim;
    Attacker attacker;

    private void Start()
    {
        anim = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Gravestone>()) anim.SetTrigger("jumpTrigger");
        else if (collision.GetComponent<Defender>()) attacker.Attack(collision.gameObject);        
    }
}
