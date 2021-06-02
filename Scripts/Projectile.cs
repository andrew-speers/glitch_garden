﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f, rotateSpeed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, 1) * rotateSpeed * Time.deltaTime);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Attacker>() != null)
        {
            GetComponent<DamageDealer>().DealDamage(collision);
            Destroy(gameObject);
        }
        
    }
}
