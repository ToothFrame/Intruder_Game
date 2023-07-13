using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float playerSpeed = 10f;
    public float sprintMultiplier = 1.5f;
    public Vector3 scale = new Vector3(1f, 1f, 1f);
    public bool isHiding = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
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

    void Update()
    {
        if (Input.GetKeyDown("c")) { isHiding = Hide(isHiding); } 
    }

    void Sprint(CharacterController controller, Vector3 move)
    {
        controller.Move(move * Time.deltaTime * sprintMultiplier * playerSpeed);
    }

    void Movement(CharacterController controller, Vector3 move)
    {
        controller.Move(move * Time.deltaTime * playerSpeed);
    }

    public bool Hide(bool isHiding)
    {
        if (!isHiding)
        {
            transform.localScale = new Vector3(1f, 0.5f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        return !isHiding;
    }

}
