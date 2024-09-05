using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


//script that manages the triggers that makes the ui appears
public class TriggerUIManager : MonoBehaviour
{
    public InteractionUI interactionUI;
    
    //if we enter the trigger the logic will work
    void OnTriggerEnter2D(Collider2D other)
    {
        //comparing if it is the player the one that entered
        if (other.CompareTag("Player"))
        {
            //showing the ui 
            string name = gameObject.name;
            interactionUI.ShowInteractText(name);
        }
    }

    //if we exit the trigger the logic will work
    void OnTriggerExit2D(Collider2D other)
    {
        //comparing if it is the player the one that exited
        if (other.CompareTag("Player"))
        {
            //hiding the ui 
            interactionUI.HideInteractText();
        }
    }

    //logic to the destroy the trigger when the interactable attached is destroyed
    public void DestroyTrigger()
    {
        Destroy(this.gameObject);
    }
}
