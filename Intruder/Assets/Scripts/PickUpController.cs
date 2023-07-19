using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour, IInteractable
{
    public ProjectileGun gunScript;
    public Rigidbody rb;
    public Transform player, gunContainer, cam;

    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;

    private void Start()
    {
        if(!equipped)
        {
            gunScript.enabled = false;
            rb.isKinematic = false;
        }
        if (equipped)
        {
            gunScript.enabled = true;
            rb.isKinematic = true;
            slotFull = true;
        }
    }


    public void Interact()
    {
        equipped = true;
        slotFull = true;

        //make weapon a child of GunContainer and move it to default pos
        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        //make Rigidbody kinematic
        rb.isKinematic = true;


        //enable script
        gunScript.enable = true;
    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;

        //set parent to nothing
        transform.SetParent(null);

        //make rb not kinematic
        rb.isKinematic = false;

        // add force
        rb.AddForce(cam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(cam.up * dropUpwardForce, ForceMode.Impulse);
        //random rotation
        //float random = random.Range(-1f, 1f);
        //rb.AddTorque(new Vector3(random,random, random)*10);

        gunScript.enable = false;
    }
}
