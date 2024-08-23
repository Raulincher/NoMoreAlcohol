using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionManager : MonoBehaviour
{
    public float interactionRange = 2f;
    public LayerMask interactableLayer;
    private float xAxis;
    Vector2 rayDirection;

    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");

        if (xAxis < 0)
        {
            rayDirection = - transform.right;
        }
        else if (xAxis > 0)
        {
            rayDirection = transform.right;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact(rayDirection);
        }
    }
    void Interact(Vector2 direction)
    {
        // Usa Physics2D.Raycast para detectar colisiones
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, interactionRange, interactableLayer);

        if (hit.collider != null)
        {
            interactionBehaviour interactable = hit.collider.GetComponent<interactionBehaviour>();
            if (interactable != null)
            {
                interactable.OnInteract();
            }
        }

        Vector2 upwardDirection = transform.up;
        RaycastHit2D hitAbove = Physics2D.Raycast(transform.position, upwardDirection, interactionRange, interactableLayer);

        if (hitAbove.collider != null)
        {
            interactionBehaviour interactable = hitAbove.collider.GetComponent<interactionBehaviour>();
            if (interactable != null)
            {
                interactable.OnInteract();
            }
        }

    }
}
