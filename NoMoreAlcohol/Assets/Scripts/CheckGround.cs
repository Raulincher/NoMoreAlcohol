using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Script that checks if our character is touching the ground or jumping.
public class CheckGround : MonoBehaviour
{
    //setting up variables for the check
    public LayerMask groundLayer; 
    public float checkDistance; 
    public Vector2 boxSize;

    /**
     * This function get the info of the collided enemy we got in the playerController
     *
     * @param none
     * 
     * 
     * @return bool //this bool will determine  
     */
    public bool isGrounded()
    {
        //we create a box under our character, this will determine if we are hitting the ground or our platforms
        if(Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, checkDistance, groundLayer))
        {
            return true;
        }
        else { return false; }
    }

    /**
     * This function will paint the box under the character to help us allocate it better
     *
     * @param none
     */
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * checkDistance, boxSize);
    }
}
