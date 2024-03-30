using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal: MonoBehaviour
{
    public string tagToCheck;
    public float x, y;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tagToCheck))
        {
            Vector2 newPosition = new Vector2(x, y);
            other.gameObject.transform.position = newPosition;

        }
    }

}
