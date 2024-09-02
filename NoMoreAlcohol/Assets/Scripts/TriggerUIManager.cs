using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TriggerUIManager : MonoBehaviour
{
    public InteractionUI interactionUI;
    
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            string name = gameObject.name;
            interactionUI.ShowInteractText(name);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactionUI.HideInteractText();
        }
    }

    public void DestroyTrigger()
    {
        Destroy(this.gameObject);
    }
}
