using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Chest : InteractionBehaviour
{
    public TriggerUIManager triggerUIManager;
    public InteractionUI interactionUI;
    public override void OnInteract()
    {
        GameObject character = GameObject.FindGameObjectWithTag("Player");
        PlayerController controller = character.GetComponent<PlayerController>();
        Inventory inventory = character.GetComponent<Inventory>();
        string objectName = gameObject.name;

        if (objectName.Contains("Jump"))
        {
            controller.doubleJumpUnlocked = true;
            triggerUIManager.DestroyTrigger();
            interactionUI.DoubleJumpChestMessageMethod();
            gameObject.SetActive(false);

        }
        else if (objectName.Equals("KeyToSecretBoss"))
        {
            inventory.secretBossKey = true;
            triggerUIManager.DestroyTrigger();
            Destroy(gameObject);
            interactionUI.SecretBossKeyMessageMethod();
        }
        else if (objectName.Equals("FinalBossKey"))
        {
            inventory.BossKey = true;
            triggerUIManager.DestroyTrigger();
            Destroy(gameObject);
            interactionUI.BossKeyChestMessageMethod();

        }
        else if (objectName.Equals("secretRoom1Key"))
        {
            inventory.keyToBossKey = true;
            triggerUIManager.DestroyTrigger();
            Destroy(gameObject);
            interactionUI.bossKeyRoomChestMessageMethod();
        }
        else if (objectName.Equals("keyToSecretBossKeyRoom"))
        {
            inventory.keyToSecretBossKey = true;
            triggerUIManager.DestroyTrigger();
            Destroy(gameObject);
            interactionUI.SecretBossKeyRoomChestMessageMethod();
        }
    }



}
