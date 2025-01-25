using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IPuzzlePiece 
{
    
    public void LinkToPuzzle(Puzzle p);
    public bool IsCorrect();
}
