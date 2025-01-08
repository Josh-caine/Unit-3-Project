using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    [SerializeField] private bool lockDoorAfterExit;
    
    public GameObject door;
    public float timer;


    private void OnTriggerEnter(Collider other) 
    {
        //Change door color (visual effects)
    }

    private void OnTriggerStay(Collider other) 
    {
        //Detect every frame im in front of the door

        if(timer > 3)
        {
            door.SetActive(false);
        }
        timer += Time.deltaTime;
    }
    private void OnTriggerExit(Collider other) 
    {
        timer = 0;
        door.SetActive(true);
    }
}
