using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.Rendering.Universal;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private Rigidbody[] correctRigidbody;
    [SerializeField] private bool unlockAnyObject;
    public UnityEvent OnPressureStart = new UnityEvent();

    public UnityEvent OnPressureExit = new UnityEvent();
private void OnTriggerEnter(Collider other) 
{
    foreach(Rigidbody rb in correctRigidbody)
    {
        if(unlockAnyObject || rb == other.attachedRigidbody)
        {
            OnPressureStart.Invoke();
            return;
        }
    }
}

private void OnTriggerExit(Collider other) 
{
    foreach(Rigidbody rb in correctRigidbody)
    {
        if(unlockAnyObject || rb == other.attachedRigidbody)
        {
            OnPressureExit.Invoke();
            return;
        }
    }

}


}
