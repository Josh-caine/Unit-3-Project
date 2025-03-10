using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class TurretIdleState : TurretState
{
    //int currentTarget = 0

    private void Start() 
    {

    }

    public TurretIdleState(TurretController turret) : base(turret)
    {

    }

    public override void OnStateEnter()
    {
        
        //turret.agent.destination = turret.targetPoints[currentTarget].position;
        //Debug.Log("Turret Idle Enter");
    }
    public override void OnStateUpdate()
    {
        if (turret.agent.remainingDistance < 1)
            {

            turret.turretEye.LookAt(turret.player);
            }
  

        if(Physics.SphereCast(turret.turretEye.position, turret.checkRadius, turret.turretEye.transform.forward, out RaycastHit hit, turret.playerCheckDistance))
        {
            if(hit.transform.CompareTag("Player"))
            {
               // Debug.Log("Player found");

                turret.player = hit.transform;
                turret.turretEye.LookAt(turret.player);
                turret.ChangeState(new TurretAttackState(turret));

            }
        
        }
    }
    public override void OnStateExit()
    {
      // Debug.Log ("Turret Idle Exiting");
    }


}

