using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script that detects an interactable object and allows the interaction with it
//the work is the fllowing, this makes a ray upwards and the way we are looking
//this ray detects the interactable layer to allow us interact with the objects inside this layer.
public class InteractionManager : MonoBehaviour
{
    public float interactionRange = 2f;
    public LayerMask interactableLayer;
    private float xAxis;
    Vector2 rayDirection;

    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");

        //here we make the ray follow the view
        if (xAxis < 0)
        {
            rayDirection = - transform.right;
        }
        else if (xAxis > 0)
        {
            rayDirection = transform.right;
        }

        //we send the ray when we hit "E"
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact(rayDirection);
        }
    }
    void Interact(Vector2 direction)
    {
        // using the raycast to detect if there is something to interact
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, interactionRange, interactableLayer);

        //check if we detect something
        if (hit.collider != null)
        {
            InteractionBehaviour interactable = hit.collider.GetComponent<InteractionBehaviour>();
            if (interactable != null)
            {
                interactable.OnInteract();
            }
        }

        //ray upwards, the same us the ray before
        Vector2 upwardDirection = transform.up;
        RaycastHit2D hitAbove = Physics2D.Raycast(transform.position, upwardDirection, interactionRange, interactableLayer);

        //if the other ray didn't detect something this will check too
        if (hitAbove.collider != null)
        {
            InteractionBehaviour interactable = hitAbove.collider.GetComponent<InteractionBehaviour>();
            if (interactable != null)
            {
                interactable.OnInteract();
            }
        }

    }
}
