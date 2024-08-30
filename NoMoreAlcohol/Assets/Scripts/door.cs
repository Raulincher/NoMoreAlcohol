using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractionBehaviour
{
    public TriggerUIManager triggerUIManager;
    public override void OnInteract()
    {
        GameObject character = GameObject.FindGameObjectWithTag("Player");
        Inventory inventory = character.GetComponent<Inventory>();

        string objectName = gameObject.name;
        if (objectName.Contains("secretDoor1") && inventory.keyToBossKey == true)
        {
            gameObject.SetActive(false);
        }
        else if (objectName.Contains("doorToBoss") && inventory.BossKey == true)
        {
            gameObject.SetActive(false);

        }
        else if (objectName.Contains("doorToSecretBoss") && inventory.secretBossKey == true)
        {
            gameObject.SetActive(false);

        }
        else if (objectName.Contains("secretBossKeyRoom") && inventory.keyToSecretBossKey == true)
        {
            gameObject.SetActive(false);

        }
        else
        {
            Debug.Log("you need the key");
        }
    }
}
