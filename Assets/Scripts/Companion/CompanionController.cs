using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;

public class CompanionController : MonoBehaviour
{

    Command currentCommand;
    [SerializeField] private Queue<Command> commandQueue = new Queue<Command>();
    
    private NavMeshAgent agent;

    private void Awake() 
    {
        agent = GetComponent<NavMeshAgent>();    
    }

    private void Update() 
    {
       if(commandQueue != null && !currentCommand.IsCommandComplete()) return;

       if(commandQueue.Count == 0) return;

       currentCommand = commandQueue.Dequeue();
       currentCommand.Excute();
    }

    public void GiveCommand(Command newCommand)
    {
        newCommand.SetCompanionController(this);
        commandQueue.Enqueue(newCommand);
    }

    public void FinishCommand()
    {
        commandQueue.Dequeue();
    }

    public NavMeshAgent GetNavMeshAgent()
    {
        return agent;
    }

}
