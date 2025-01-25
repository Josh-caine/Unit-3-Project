using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This ability is specific for ai characters which can attack the player in different ways
/// </summary>
public class AttackAbility : MonoBehaviour
{

    [SerializeField] private float _damageToGive;
    [SerializeField] private float _attackCooldown;

    private bool isAttacking;
    private float attackTimer;
    private HealthSystem targetToAttack;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isAttacking)
        {
            //Start Timer
            attackTimer += Time.deltaTime;
            if(attackTimer >= _attackCooldown)
            {
                Attack();
                attackTimer = 0;
            }
        }
    }

    public void StartAttack(Transform target)
    {
        targetToAttack = target.GetComponent<HealthSystem>();
        Debug.Log("Started attack with another script");
        isAttacking = true;
    }

    public void Attack()
    {
        //Deal damage to target
        if(targetToAttack)
        {
            targetToAttack.DecreaseHealth(_damageToGive);
        }

    }
    
    public void StopAttack()
    {
        isAttacking = false;
    }
}
