using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    //public bool isGrounded = false;
    public LayerMask groundLayer; 
    public float checkDistance; 
    public Vector2 boxSize;


    public bool isGrounded()
    {
        if(Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, checkDistance, groundLayer))
        {
            return true;
        }
        else { return false; }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * checkDistance, boxSize);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Map"))
    //    {
    //        //Vector3 normal = collision.GetContact(0).normal;
    //        RaycastHit2D hit = Physics2D.BoxCast(transform.position, GetComponent<Collider2D>().bounds.size, 0f, Vector2.down, checkDistance, groundLayer);
    //        if (hit.collider != null)
    //        {
    //            isGrounded = true;
    //        }
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Map"))
    //    {
    //        isGrounded = false;
    //    }
    //}
}
