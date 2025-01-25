using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveCommand : Command
{
    private Vector3 target;
    public override void Cancel()
    {

    }

    public override void Excute()
    {
        //if(companionController.GetNavMeshAgent().hasPath) return;

        companionController.GetNavMeshAgent().SetDestination(target);
    }

    public override bool IsCommandComplete()
    {
        float distance = Vector3.Distance(target, companionController.transform.position);
        Debug.Log(distance);
        return Vector3.Distance(target, companionController.transform.position) < 1.5f;
       
        
            
    }

    public MoveCommand(Vector3 position)
    {
        target = position;
    }
}
