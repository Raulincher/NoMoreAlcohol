using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//deprecated script that tries to replicate (not finished) the behaviour some games have.
//The behaviour mentioned is the one that the player jumps from under the platform and the platform let it go through it
public class Platforms : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null && rb.velocity.y <= 0)
            {
                Collider2D platformCollider = GetComponent<Collider2D>();
                platformCollider.isTrigger = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Collider2D platformCollider = GetComponent<Collider2D>();
            platformCollider.isTrigger = true;
        }
    }
}
