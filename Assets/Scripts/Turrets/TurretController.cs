using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class TurretController : MonoBehaviour
{
    private TurretState currentState;
    public Transform[] targetPoints;
    public Transform turretEye;

    public float playerCheckDistance;
    public float checkRadius;
    public NavMeshAgent agent;
    public Transform player;
    public float dis;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        currentState = new TurretIdleState(this);
    }
    void Start()
    {
        currentState.OnStateEnter();
    }
    void Update()
    {
        currentState.OnStateUpdate();
    }
    public void ChangeState(TurretState state)
    {
        currentState.OnStateExit();
        currentState = state;
        currentState.OnStateEnter();
    }

    public void OnDrawGizmos()
    { 
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(turretEye.position, checkRadius);
        Gizmos.DrawWireSphere(turretEye.position + turretEye.forward * playerCheckDistance, checkRadius);
        Gizmos.DrawLine(turretEye.position, turretEye.position + turretEye.forward * playerCheckDistance);
    }

}
