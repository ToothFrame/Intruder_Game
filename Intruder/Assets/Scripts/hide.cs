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
    public bool isInteractable;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");     
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && isInteractable) 
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
        if (isInteractable)
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
