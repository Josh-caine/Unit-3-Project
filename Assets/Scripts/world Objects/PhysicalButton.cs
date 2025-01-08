using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class PhysicalButton : MonoBehaviour, IInteractable
{
    //public UnityEvent OnPressed;
   // public GameObject doorObject;
   public Action OnPressed;
    public void StartInteraction()
    {
        Debug.Log("Pressed Button");
       // doorObject.SetActive(false);
       OnPressed?.Invoke();
    }

    public void StopInteraction()
    {
    }

}
