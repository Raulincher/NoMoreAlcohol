using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class chest : interactionBehaviour
{
    public override void OnInteract()
    {
        string objectName = gameObject.name;
        if (objectName.Contains("Jump"))
        {
            GameObject character = GameObject.FindGameObjectWithTag("Player");
            PlayerController controller = character.GetComponent<PlayerController>();
            controller.doubleJumpUnlocked = true;
            Destroy(gameObject);
        }
    }
}