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
    public GameObject introCanvis;

    private void Start() 
    {
        finalPuzzle.OnPuzzleCompleted.AddListener(GameCompleted);
        introCanvis.SetActive(true);
        
    }

    public void StartGame()
    {
        introCanvis.SetActive(false);
    }

    public void GameCompleted()
    {
        OnFinalPuzzleCompleted.Invoke();
        //Save progress
    }
}
