using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class lightSwitch : MonoBehaviour
{
    //boolean di stato per la variabile
    public bool lightOn; 
    //GameObject per attivare/disattivare la luce
    public GameObject lightSource; 
    //Testo per segnalare l'interazione

    public TMP_Text statusText;
    public bool isPlayerInTrigger; //Ho mantenuto la variabile, che ora è gestita da mouse look 
    public AudioSource switchAudio; //risorsa audio pe riprodurre il suono

    //Questa funzione viene triggerata quando un altro oggetto entra nel trigger (Collider è la variabile per stabilire l'oggetto)
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && isPlayerInTrigger) //Se il player è nel trigger e premo il tasto sinistro, accendo/spengo la luce.
        {
            updateLight();
        }
    }

    void updateLight()
    {
        switchAudio.Play();  //Riproduco audio
        if (lightOn)
        {
            lightOn = false;
            lightSource.SetActive(lightOn);
        }
        else
        {
            lightOn = true;
            lightSource.SetActive(lightOn);
        }
        updateText(); 
    }

    public void updateText()
    {
        if (isPlayerInTrigger)
        {
            if (lightOn)
            {
                statusText.text = "Press 'LMB' to turn light off";
            }
            else
            {
                statusText.text = "Press 'LMB' to turn light on";
            }
        }
        else
        {
            statusText.text = "";
        }
    }
}
