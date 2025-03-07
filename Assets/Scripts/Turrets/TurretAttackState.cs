using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttackState : TurretState
{
    float distanceToPlayer;

    AttackAbility attackAbility;
    LineRenderer line;

    public TurretAttackState(TurretController turret) : base(turret)
    {
        attackAbility = turret.GetComponent<AttackAbility>();

    }
    public override void OnStateEnter()
    {
        if(attackAbility != null)
        {
            
            attackAbility.StartAttack(turret.player);
            
        }
    }
    public override void OnStateUpdate()
    {
        if(turret.player != null)
        {
            distanceToPlayer = Vector3.Distance(turret.transform.position, turret.player.position);
            if(distanceToPlayer > 5)
            {
                turret.ChangeState( new TurretIdleState(turret));
            }
            //turret.agent.destination = turret.player.position;
            turret.turretEye.LookAt(turret.player);
        }
    }
    public override void OnStateExit()
    {
        if(attackAbility != null)
        {
            attackAbility.StopAttack();
        }
    }


}
