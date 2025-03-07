using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Examples : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PowerOf(int number, int power)
    {
        int value = number;
        for(int i = 1; i< power; i++)
        {
            value = value * number;
        }
    }

}
