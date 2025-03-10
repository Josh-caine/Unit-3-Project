using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PressurePlate : MonoBehaviour, IPuzzlePiece
{
    [SerializeField] private bool unlockWithAnyObject;
    [SerializeField] private Rigidbody[] correctRigidbodies;

    public UnityEvent OnPressureStart = new UnityEvent();
    public UnityEvent OnPressureExit = new UnityEvent();
    [SerializeField] private Vector3 openOffset;
    [SerializeField] private float dropSpeed;
    private Vector3 startPosition;
    [SerializeField] AudioSource boxAudio;

    protected bool isPressed;
    private void OnTriggerStay(Collider other)
    {
        if(unlockWithAnyObject)
        {
            OnPressureStart?.Invoke();
            isPressed = true;
            boxAudio.Play();
            return;
        }

        foreach (Rigidbody rb in correctRigidbodies)
        {
            if (rb == other.attachedRigidbody)
            {
                OnPressureStart?.Invoke();
                isPressed = true;
                return;
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {

        foreach (Rigidbody rb in correctRigidbodies)
        {
            if (unlockWithAnyObject || rb == other.attachedRigidbody)
            {
                OnPressureExit?.Invoke();
                isPressed = false;
                return;
            }
        }
        
    }


    //IMPLEMENTATION OF INTERFACE INTO PRESSURE PAD/PLATE
    public bool IsCorrect()
    {
        //isPressed is a simple boolean created in the pressure plate and it says when there is a rigidbody above it
        return isPressed;
    }
}