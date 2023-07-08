using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class noiseMaker : MonoBehaviour
{
    public bool noise;

    public TMP_Text statusText;
    public bool isPlayerInTrigger; 
    public AudioSource switchAudio; 


    void Update()
    {
        if (Input.GetButtonDown("Fire1") && isPlayerInTrigger) 
        {
            updateLight();
        }
    }

    void updateLight()
    {
         //Riproduco audio
        if (noise)
        {
            noise = false;
            switchAudio.Stop();
        }
        else
        {
            noise = true;
            switchAudio.Play();
        }
        updateText();
    }

    public void updateText()
    {
        if (isPlayerInTrigger)
        {
            if (noise)
            {
                statusText.text = "Press 'LMB' to stop N O I S E";
            }
            else
            {
                statusText.text = "Press 'LMB' to make N O I S E";
            }
        }
        else
        {
            statusText.text = "";
        }
    }
}
