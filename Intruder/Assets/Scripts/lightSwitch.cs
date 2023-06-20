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

    //Questa funzione viene triggerata quando un altro oggetto entra nel trigger (Collider è la variabile per stabilire l'oggetto)
    private void OnTriggerEnter(Collider other)
    {
        //aggiorno il testo sempre in un altra funzione

        //controllo che la tag dell'oggetto sia 'Player'

        if (other.tag == "Player")
            updateText(); 

       
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown("e"))
            {
                updateLight(); 
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            statusText.text = ""; 
        }
    }

    void updateLight()
    {
        if(lightOn)
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

    void updateText()
    {
        if (lightOn)
        {
            statusText.text = "Press 'e' to turn light off";
        }
        else
        {
            statusText.text = "Press 'e' to turn light on";
        }
        
    }
}
