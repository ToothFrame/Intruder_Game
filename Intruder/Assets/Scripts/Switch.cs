using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour, IInteractable
{
    public GameObject lamp;
    public void Interact()
    {
        lamp.SetActive(!lamp.activeSelf);
        Debug.Log("CAZZOMMERDA SIIIIIIIIIIIIIIIIIIIII");
    }
}
