using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    //[Range(0, 5)] [SerializeField] float walkSpeed = 1f;
    float currentSpeed = 1f;
    GameObject currentTarget;
    Animator anim;
    GameState state;

    private void Start()
    {
        anim = GetComponent<Animator>();
        state = FindObjectOfType<GameState>();
        state.NewAttacker();

        GetComponent<Health>().ModifyHealth(DifficultyPresets.GetEnemyHealthMod());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);

        if (!currentTarget) anim.SetBool("isAttacking", false);
    }

    private void OnDestroy()
    {
        state.AttackerDied();
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        currentTarget = target; 
        anim.SetBool("isAttacking", true);
    }

    public void HitTarget(float damage)
    {
        if (!currentTarget) return;

        Health health = currentTarget.GetComponent<Health>();
        if (health) health.Damage(damage * DifficultyPresets.GetEnemyDamageMod());        
    }
}
