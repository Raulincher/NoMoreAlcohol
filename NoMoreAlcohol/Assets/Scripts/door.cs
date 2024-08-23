using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : interactionBehaviour
{
    public TriggerUIManager triggerUIManager;
    public override void OnInteract()
    {
        string objectName = gameObject.name;
        if (objectName.Contains("1"))
        {
            Debug.Log("okey");
        }
        else if (objectName.Contains("doorToBoss"))
        {
            Debug.Log("okey2");

        }
    }
}
