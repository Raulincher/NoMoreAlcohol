using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Chest : InteractionBehaviour
{
    public TriggerUIManager triggerUIManager;
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
            Destroy(gameObject);
        }
        else if (objectName.Equals("KeyToSecretBoss"))
        {
            inventory.secretBossKey = true;
            Debug.Log("entro secret");
        }
        else if (objectName.Equals("FinalBossKey"))
        {
            inventory.BossKey = true;
            Debug.Log("entro boss");

        }
        else if (objectName.Equals("secretRoom1Key"))
        {
            inventory.keyToBossKey = true;
            Debug.Log("entro room boss");

        }
        else if (objectName.Equals("keyToSecretBossKeyRoom"))
        {
            inventory.keyToSecretBossKey = true;
            Debug.Log("entro room secret");

        }
    }
}
