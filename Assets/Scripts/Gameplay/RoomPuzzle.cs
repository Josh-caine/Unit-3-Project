using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RoomPuzzle : Puzzle
{
    private IPuzzlePiece[] allPuzzlePieces;

    private void Awake() 
    {
        allPuzzlePieces = GetComponentsInChildren<IPuzzlePiece>();
        foreach (IPuzzlePiece piece in allPuzzlePieces)
        {
            piece.LinkToPuzzle(this);
        }
    }

    public void Update()
    {
        if(CheckSolution() && isPuzzleComplete == false)
        {
            onPuzzleCompleted?.Invoke();
            isPuzzleComplete = true;
        }
    }
    public override bool CheckSolution()
    {
        foreach (IPuzzlePiece piece in allPuzzlePieces)
        {
            if(!piece.IsCorrect())
            {
                return false;
            }
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            isPuzzleActive = true;
        }
        
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            isPuzzleActive = false;
        }
    }
}
