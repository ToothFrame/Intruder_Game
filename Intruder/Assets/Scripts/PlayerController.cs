using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float playerSpeed = 10f;
    public float sprintMultiplier = 1.5f;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if(Input.GetKey("left shift"))
        {
            Sprint(controller, move);
        }
        else
        {
            Movement(controller, move);
        }
    }

    void Sprint(CharacterController controller, Vector3 move)
    {
        controller.Move(move * Time.deltaTime * sprintMultiplier * playerSpeed);
    }
    void Movement(CharacterController controller, Vector3 move)
    {
        controller.Move(move * Time.deltaTime * playerSpeed);
    }

}
