using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public Camera cam;
    public InteractionText intText;
    private RaycastHit hit;
    public float range;
    public string colliderTag;
    // Start is called before the first frame update
    void Start()
    {
        range = 2.0f;
        colliderTag = string.Empty;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool ray = Physics.Raycast(cam.transform.position, transform.TransformDirection(Vector3.forward), out hit, range);
        if (ray)
        {
            colliderTag = hit.collider.tag;
            intText.UpdateText(colliderTag);
            print(hit.collider.tag);
        }
        else
        {
            intText.ResetText();
        }
    }
}
