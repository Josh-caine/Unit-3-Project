using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public UnityEvent OnGameStart = new UnityEvent();
    public UnityEvent OnFinalPuzzleCompleted = new UnityEvent();
    
    [SerializeField] private Puzzle finalPuzzle;

    private void Start() 
    {
        finalPuzzle.OnPuzzleCompleted.AddListener(GameCompleted);
    }

    public void StartGame()
    {
       //enblr player movement
       //start timer
    }

    public void GameCompleted()
    {
        OnFinalPuzzleCompleted.Invoke();
        //Save progress
    }
}
