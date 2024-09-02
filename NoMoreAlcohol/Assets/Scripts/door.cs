using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractionBehaviour
{
    public TriggerUIManager triggerUIManager;
    public InteractionUI interactionUI;

    public override void OnInteract()
    {
        GameObject character = GameObject.FindGameObjectWithTag("Player");
        Inventory inventory = character.GetComponent<Inventory>();

        string objectName = gameObject.name;
        if (objectName.Contains("secretDoor1") && inventory.keyToBossKey == true)
        {
            Destroy(gameObject);
            triggerUIManager.DestroyTrigger();
            interactionUI.bossKeyRoomMessageMethod();
        }
        else if (objectName.Contains("doorToBoss") && inventory.BossKey == true)
        {
            Destroy(gameObject);
            triggerUIManager.DestroyTrigger();
            interactionUI.bossRoomMessageMethod();
        }
        else if (objectName.Contains("doorToSecretBoss") && inventory.secretBossKey == true)
        {
            Destroy(gameObject);
            triggerUIManager.DestroyTrigger();
            interactionUI.SecretBossMessageMethod();
        }
        else if (objectName.Contains("secretBossKeyRoom") && inventory.keyToSecretBossKey == true)
        {
            Destroy(gameObject);
            triggerUIManager.DestroyTrigger();
            interactionUI.DoorMessageSecretBossKeyRoomMethod();
        }
    }
}
