using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class hide : MonoBehaviour
{
    
    public bool isHide;
    
    public GameObject player;
    public GameObject hideCam;

    public TMP_Text statusText;
    public bool isPlayerInTrigger;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");     
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && isPlayerInTrigger) 
        {
            updateLight();
        }
    }

    void updateLight()
    {
       
        if (isHide)
        {
            isHide = false;
            player.SetActive(!isHide);
            hideCam.SetActive(isHide);
        }
        else
        {
            isHide = true;
            player.SetActive(!isHide);
            hideCam.SetActive(isHide);
        }
        updateText();
    }

    public void updateText()
    {
        if (isPlayerInTrigger)
        {
            if (isHide)
            {
                statusText.text = "Press 'LMB' to Exit";
            }
            else
            {
                statusText.text = "Press 'LMB' to Hide";
            }
        }
        else
        {
            statusText.text = "";
        }
    }
}
