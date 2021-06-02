using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] float damage = 100f;

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //Debug.Log(collision.gameObject.name);
    //    collision.GetComponent<Health>().Damage(damage);
    //    Destroy(gameObject);
    //}
    public void DealDamage(Collider2D collision)
    {
        Health h = collision.GetComponent<Health>();
        if (h != null)
        {
            h.Damage(damage);
        }        
    }
}
