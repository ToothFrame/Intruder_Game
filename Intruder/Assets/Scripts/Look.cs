using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    public float sensitivity = 500f;
    public Transform player;
    float xRotation = 0f;
    public Camera cam;
    public lightSwitch lastSwitch; 

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
       
        RaycastHit hit; //variabile che mi restituisce ciò che il raggio 
        Debug.DrawRay(cam.transform.position, transform.TransformDirection(Vector3.forward), Color.green); 

        if (Physics.Raycast(cam.transform.position, transform.TransformDirection(Vector3.forward), out hit, 1f)) //"sparo" un raggio dall'origine della camera, lungo 2 unità
        {
            //Debug.DrawRay(cam.transform.position, transform.TransformDirection(Vector3.forward), Color.red);
            if (hit.transform.tag == "Switch") //se colpisco qualcosa con tag switch
            {
                Debug.DrawRay(cam.transform.position, transform.TransformDirection(Vector3.forward), Color.yellow);
                lastSwitch = hit.transform.GetComponent<lightSwitch>();
                lastSwitch.isPlayerInTrigger = true; //vado ad attivare player on trigger per dire a unity che si può attivare la luce
                lastSwitch.updateText();
            }
            if(hit.transform.tag == "Door")
            {
                Debug.DrawRay(cam.transform.position, transform.TransformDirection(Vector3.forward), Color.red);
            }
        } else
        {
            if(lastSwitch != null)  //se non ho mai colpito un interruttore non faccio assolutamente nulla
            {
                lastSwitch.isPlayerInTrigger = false; //se non colpisco nulla, resetto lo stato dell'ultimo iterruttore
                lastSwitch.updateText();
            }
        }

        //sfrutto l'ultimo interruttore per il semice fatto che "Hit" è una variabile locale. quando esco con il mouse dalla zona dell'interruttore su hit non avrò più nulla
        //mettendo l'ultimo interruttore, quando la mia visuale si gira, so dove andare a resettare lo stato

        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime; 
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
        
    }
}
