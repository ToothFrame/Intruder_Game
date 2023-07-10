using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionText : MonoBehaviour
{
    public TMP_Text statusText;
    // Start is called before the first frame update
    void Start()
    {
        statusText.text = "";
    }
    
    public void UpdateText(string tag)
    {
        switch (tag)
        {
            case ("Switch"):
                statusText.text = "Switch";
                break;
            case ("Noisemaker"):
                statusText.text = "Noisemaker";
                break;
            default:
                statusText.text = "";
                break;
        }
    }
    
    public void ResetText()
    {
        statusText.text = "";
    }
}
