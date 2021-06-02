using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float startHealth = 100f;
    [SerializeField] GameObject deathVFXPrefab = null;

    float health;
    private void Start()
    {
        health = startHealth;
    }
    
    public void Damage(float hp)
    {
        health -= hp;
        if (health <= 0)
        {
            Death();            
        }        
    }

    void Death()
    {
        Destroy(gameObject);
        if (deathVFXPrefab != null)
        {            
            GameObject deathVFXObject = Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
            Destroy(deathVFXObject, 1f);
        }
        
    }

    public void ModifyHealth(float mod)
    {
        health *= mod;
    }
}
