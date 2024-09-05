using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Child from the interactionBehaviour script this script will manage the interactions with our doors.
public class Door : InteractionBehaviour
{
    public TriggerUIManager triggerUIManager;
    public InteractionUI interactionUI;

    /**
     * This function manage the interaction with a door.
     *
     * @param none
     */
    public override void OnInteract()
    {
        //we import some variables and set up anothers
        GameObject character = GameObject.FindGameObjectWithTag("Player");
        Inventory inventory = character.GetComponent<Inventory>();

        //here we separate our doors by name, that will help us know which door was interacted.
        //Also, we detect if the character has the correct key to open it.
        string objectName = gameObject.name;
        if (objectName.Contains("secretDoor1") && inventory.keyToBossKey == true)
        {
            //Door to main boss room key
            Destroy(gameObject);
            triggerUIManager.DestroyTrigger();
            interactionUI.bossKeyRoomMessageMethod();
        }
        else if (objectName.Contains("doorToBoss") && inventory.BossKey == true)
        {
            //door to main boss
            Destroy(gameObject);
            triggerUIManager.DestroyTrigger();
            interactionUI.bossRoomMessageMethod();
        }
        else if (objectName.Contains("doorToSecretBoss") && inventory.secretBossKey == true)
        {
            //door to secret boss
            Destroy(gameObject);
            triggerUIManager.DestroyTrigger();
            interactionUI.SecretBossMessageMethod();
        }
        else if (objectName.Contains("secretBossKeyRoom") && inventory.keyToSecretBossKey == true)
        {
            //Door to secret boss room key
            Destroy(gameObject);
            triggerUIManager.DestroyTrigger();
            interactionUI.DoorMessageSecretBossKeyRoomMethod();
        }
    }
}
