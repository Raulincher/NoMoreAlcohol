using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;


//Child from the interactionBehaviour script this script will manage the interactions with our chests.
public class Chest : InteractionBehaviour
{
    public TriggerUIManager triggerUIManager;
    public InteractionUI interactionUI;

    /**
     * This function manage the interaction with a chest.
     *
     * @param none
     */
    public override void OnInteract()
    {

        //we import some variables and set up anothers
        GameObject character = GameObject.FindGameObjectWithTag("Player");
        PlayerController controller = character.GetComponent<PlayerController>();
        Inventory inventory = character.GetComponent<Inventory>();
        string objectName = gameObject.name;

        //here we separate our chests by name, that will help us know which chest was interacted
        if (objectName.Contains("Jump"))
        {
            //unlocks the double jump feature
            controller.doubleJumpUnlocked = true;
            triggerUIManager.DestroyTrigger();
            interactionUI.DoubleJumpChestMessageMethod();
            gameObject.SetActive(false);

        }
        else if (objectName.Equals("KeyToSecretBoss"))
        {
            //gives the character the key to go to the secret boss
            inventory.secretBossKey = true;
            triggerUIManager.DestroyTrigger();
            Destroy(gameObject);
            interactionUI.SecretBossKeyMessageMethod();
        }
        else if (objectName.Equals("FinalBossKey"))
        {
            //gives the character the key to go to the final boss
            inventory.BossKey = true;
            triggerUIManager.DestroyTrigger();
            Destroy(gameObject);
            interactionUI.BossKeyChestMessageMethod();

        }
        else if (objectName.Equals("secretRoom1Key"))
        {
            //gives the character the key to go to the final boss key room
            inventory.keyToBossKey = true;
            triggerUIManager.DestroyTrigger();
            Destroy(gameObject);
            interactionUI.bossKeyRoomChestMessageMethod();
        }
        else if (objectName.Equals("keyToSecretBossKeyRoom"))
        {

            //gives the character the key to go to the secret boss key room
            inventory.keyToSecretBossKey = true;
            triggerUIManager.DestroyTrigger();
            Destroy(gameObject);
            interactionUI.SecretBossKeyRoomChestMessageMethod();
        }
    }



}
