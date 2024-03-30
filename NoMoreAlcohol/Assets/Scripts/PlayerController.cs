using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{

    public float speed = 2;
    public float jump = 3;
    public GameObject battleSystem;

    Rigidbody2D rb2d;
    public string PlayerName;
    public int Damage;

    public int MaxHP;
    public int CurrentHP;

    public event Action OnEncountered;

    public HealthBar HealthBar;

    private Vector3 previousPosition;



    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        CurrentHP = MaxHP;
        previousPosition = transform.position;
        HealthBar.SetMaxHealth(MaxHP);
    }

    // Update is called once per frame
    public void Update()
    {
        if (!battleSystem.activeSelf)
        {
            CheckGround checkGround = GetComponent<CheckGround>();
            bool check = checkGround.isGrounded;

            MovePlayer(check);


            if (transform.position != previousPosition)
            {
                CheckForEncounters();
            }

            // Update the previous position to the current position
            previousPosition = transform.position;
        }
    }


    void MovePlayer(bool check)
    {
        // Detect player input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(horizontalInput * speed, rb2d.velocity.y);

        // Check if the player is jumping
        if (Input.GetButtonDown("Jump") && check)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jump);
        }
    }

    /*IEnumerator CheckEncounter()
    {
        CheckForEncounters();
        yield return new WaitForSeconds(10);
        StartCoroutine(CheckEncounter());
    }*/

    public bool ReceiveDamage(int Damage)
    {
        CurrentHP -= Damage;
        HealthBar.SetHealth(CurrentHP);
        if (CurrentHP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    private void CheckForEncounters()
    {

        int num = UnityEngine.Random.Range(1, 1001);
        if (num <= 4)
        {
            OnEncountered();
        }
    }
}
