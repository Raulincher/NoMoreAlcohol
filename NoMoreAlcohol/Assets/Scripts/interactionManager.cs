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
            Debug.Log("entro izquierda");
        }
        else if (xAxis > 0)
        {
            rayDirection = transform.right;
            Debug.Log("entro derecha");

        }

        // Dibuja un rayo hacia adelante desde la posición actual
        Debug.DrawRay(transform.position, rayDirection * interactionRange, Color.red, 0.1f);

        

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("entro en e");
            Interact(rayDirection);
        }
    }

    void Interact(Vector2 direction)
    {
        // Usa Physics2D.Raycast para detectar colisiones
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, interactionRange, interactableLayer);

        if (hit.collider != null)
        {
            Debug.Log("Objeto detectado");
            interactionBehaviour interactable = hit.collider.GetComponent<interactionBehaviour>();
            if (interactable != null)
            {
                Debug.Log("Interacting with: " + interactable.gameObject.name);
                interactable.OnInteract();
            }
        }
        else
        {
            Debug.Log("No interactuable detectado");
        }
    }
}
