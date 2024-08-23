using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerUIManager : MonoBehaviour
{
    public InteractionUI interactionUI;
    
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            interactionUI.ShowInteractText();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("salgo collider de cofre");
            interactionUI.HideInteractText();
        }
    }

    public void DestroyTrigger()
    {
        Destroy(gameObject);
    }
}
