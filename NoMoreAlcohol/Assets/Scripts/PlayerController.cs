using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

//Script que controla todo lo relacionado con el personaje principal, tanto en combate como fuera de el.
//Este script esta siendo observado por GameController para así saber cuando hay un evento de pelea.
public class PlayerController : MonoBehaviour
{
    [Header("Horizontal Movement Settings")]
    private float xAxis;
    [SerializeField] public float speed = 9;
    Rigidbody2D rb2d;


    [Header("Vertical Movement Settings")]
    public float jump = 3;
    public int airJumpCounter = 0;
    public int maxAirJumps = 2;
    PlayerStateList playerStateList;

    [Header("Buffer Settings")]
    private int jumpBufferCounter = 0;
    [SerializeField] private int jumpBufferFrames;


    [Header("Battlesystem")]
    public GameObject battleSystem;
    public BattleSystem BattleScript;
    public string PlayerName;
    public int Damage;
    public int MaxHP;
    public int CurrentHP;
    public HealthBar HealthBar;
    public event Action EnemyEncounter;
    public GameObject enemyCollision;



    void Start()
    {
        playerStateList = GetComponent<PlayerStateList>();
        rb2d = GetComponent<Rigidbody2D>();
        CurrentHP = MaxHP;
        HealthBar.SetMaxHealth(MaxHP);
    }

    // Update is called once per frame
    public void Update()
    {
        if (!battleSystem.activeSelf)
        {
            CheckGround checkGround = GetComponent<CheckGround>();
            bool check = checkGround.isGrounded();
            GetInputs();
            resetJumpVaribles(check);
            Move();
            Flip();
            Jump(check);
            
            //MovePlayer(check);

        }
    }

    void GetInputs()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
    }

    private void Move()
    {
        rb2d.velocity = new Vector2(speed * xAxis, rb2d.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyCollision = collision.gameObject;
            BattleScript = battleSystem.GetComponent<BattleSystem>();
            BattleScript.HandleCollision(enemyCollision);

            EnemyEncounter();
        }
    }
    void Flip()
    {
        if(xAxis < 0)
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
        else if(xAxis > 0)
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
    }

 

    private void Jump(bool check)
    {

        if (!playerStateList.jumping)
        {
            if (jumpBufferCounter > 0 && check)
            {
                //playerStateList.jumping = true;
                rb2d.velocity = new Vector2(rb2d.velocity.x, jump);
                playerStateList.jumping = true;

            }
        }



        if (Input.GetButtonUp("Jump") && rb2d.velocity.y > 0)
        {
            //playerStateList.jumping = true;
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            playerStateList.jumping = false;
        }
        
    }

    void resetJumpVaribles(bool check)
    {
        if (check)
        {
            playerStateList.jumping = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferFrames;
        }
        else
        {
            jumpBufferCounter--;
        }
    }

    /*void MovePlayer(bool check)
    {
        // Detect player input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(horizontalInput, rb2d.velocity.y);
        // Check if the player is jumping
        if (check)
        {
            airJumpCounter = 0;
            playerStateList.jumping = false;
        }

        if (Input.GetButtonDown("Jump") && check)
        {
            playerStateList.jumping = true;
            rb2d.velocity = new Vector2(rb2d.velocity.x, jump);
        }
    }*/

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

    public void heal(int heal)
    {
        CurrentHP += heal;
        if(CurrentHP > MaxHP)
        {
            CurrentHP = MaxHP;
        }
        HealthBar.SetHealth(CurrentHP);

    }

}
