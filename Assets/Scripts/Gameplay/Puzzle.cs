using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public abstract class  Puzzle : MonoBehaviour
{
    public UnityEvent onPuzzleCompleted; 
    public bool isPuzzleActive;
    public bool isPuzzleComplete;
    public abstract bool CheckSolution();
}
