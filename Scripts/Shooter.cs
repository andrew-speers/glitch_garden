using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab = null;
    [SerializeField] Transform gun = null;

    AttackerSpawner myAttackerSpawner;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        foreach (AttackerSpawner spawner in FindObjectsOfType<AttackerSpawner>())
        {
            if (Mathf.Abs(transform.position.y - spawner.transform.position.y) < Mathf.Epsilon) myAttackerSpawner = spawner;
        }
    }

    private void Update()
    {
        anim.SetBool("isAttacking", myAttackerSpawner.transform.childCount > 0);
    }
    
    public void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab, gun.position, Quaternion.identity);        
    }
}
