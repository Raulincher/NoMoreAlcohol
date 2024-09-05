using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////Script that controls the camera movement (old one)
//this movement is not used now but the ifdea of it was use it to make the camera follow the character within the map
//the type of camera that it is used now is the "room" type one.
public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 2f;
    public float yOffset = 1f;

    private void FixedUpdate()
    {
        if(target != null)
        {
            Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10);
            transform.position = Vector3.Slerp(transform.position, newPos, smoothSpeed * Time.deltaTime);
        }
    }
}
