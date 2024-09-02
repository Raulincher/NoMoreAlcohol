using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

//Script que controla todo lo relacionado con el personaje principal, tanto en combate como fuera de el.
//Este script esta siendo observado por GameController para as� saber cuando hay un evento de pelea.
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
    public int jumpCounter = 0;
    public bool doubleJump = false;
    public bool doubleJumpUnlocked = false;
    public float maxFallSpeed = -20f;

    [Header("Buffer Settings")]
    private int jumpBufferCounter = 0;
    [SerializeField] private int jumpBufferFrames;


    [Header("Battlesystem")]
    public GameObject battleSystem;
    public BattleSystem BattleScript;
    public string playerName;
    public float damage;
    public float maxHP;
    public float currentHP;
    public HealthBar healthBar;
    public event Action enemyEncounter;
    public GameObject enemyCollision;
    public float statsMultiplier = 1;

    private float healCooldown = 2f;
    public HealTextFollow healTextFollow;
    private int currentHealCount = 0;
    private int maxHeals = 3;
    private float lastHealTime = 0f;


    private bool gamePaused;

    void Start()
    {
        playerStateList = GetComponent<PlayerStateList>();
        rb2d = GetComponent<Rigidbody2D>();
        string savedName = PlayerPrefs.GetString("UserInput", "");
        if (savedName.Equals(""))
        {
            savedName = "John";
        }
        playerName = savedName;
        currentHP = maxHP;
        healthBar.SetMaxHealth(maxHP);
    }

    // M�todo que se invoca al pausar el juego
    public void OnPause()
    {
        gamePaused = true;
    }

    // M�todo que se invoca al reanudar el juego
    public void OnResume()
    {
        gamePaused = false;
    }


    public void Update()
    {
        if (gamePaused == false)
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
                if (Input.GetKeyDown(KeyCode.H) && currentHealCount < maxHeals && Time.time > lastHealTime + healCooldown)
                {
                    HealCharacter();
                }

                if (rb2d.velocity.y < maxFallSpeed)
                {
                    rb2d.velocity = new Vector2(rb2d.velocity.x, maxFallSpeed);
                }

            }
        }
    }

    void HealCharacter()
    {
        lastHealTime = Time.time;

        Debug.Log("curo");
        currentHealCount++;

        currentHP = maxHP;
        healTextFollow.HealCharacter();

    }

    void GetInputs()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
    }

    public void levelUpCharacter()
    {
        statsMultiplier = statsMultiplier + 0.1f;
        damage = 5 * statsMultiplier;
        maxHP = 15 * statsMultiplier;
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

            enemyEncounter();
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

        if(check && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (check)
            {
                // Primer salto
                rb2d.velocity = new Vector2(rb2d.velocity.x, jump);
                doubleJump = true; // Permitir un doble salto despu�s de un salto normal
            }
            else if (doubleJump && doubleJumpUnlocked)
            {
                // Doble salto
                rb2d.velocity = new Vector2(rb2d.velocity.x, jump);
                doubleJump = false; // Desactivar el doble salto hasta que se vuelva a tocar el suelo
            }
        }

        if (Input.GetButtonUp("Jump") && rb2d.velocity.y > 0f)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y * 0.5f);
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

    public bool ReceiveDamage(float damage)
    {
        currentHP -= damage;
        healthBar.SetHealth(currentHP);
        if (currentHP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void heal(float heal)
    {
        currentHP += heal;
        if(currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        healthBar.SetHealth(currentHP);

    }

}
