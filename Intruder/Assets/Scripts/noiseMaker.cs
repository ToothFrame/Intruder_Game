using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseMaker : MonoBehaviour, IInteractable
{
    public AudioSource noiseMaker;
    public bool isToggled = false;
    public void Interact()
    {
        if (!isToggled)
        {
            noiseMaker.Play();
            isToggled = true;
        }
        else
        {
            noiseMaker.Stop();
            isToggled = false;
        }
        Debug.Log("sono un noisemaker SI CAZZO");
    }
}

