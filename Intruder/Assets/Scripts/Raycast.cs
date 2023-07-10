using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    public void Interact();
}

public class Raycast : MonoBehaviour
{
    public Transform InteractorSource;
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
    void Update()
    {
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        //bool ray = Physics.Raycast(cam.transform.position, transform.TransformDirection(Vector3.forward), out hit, range);
        if (Physics.Raycast(r, out RaycastHit hitInfo, range))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObject) && Input.GetMouseButtonDown(0))
            {
                interactObject.Interact();
            }
           // colliderTag = hit.collider.tag;
            intText.UpdateText(hitInfo.collider.tag);
            //print(hit.collider.tag);
        }
        else
        {
            intText.ResetText();
        }
    }
}
