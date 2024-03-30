using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
