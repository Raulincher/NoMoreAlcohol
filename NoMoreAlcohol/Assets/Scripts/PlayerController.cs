using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using static UnityEngine.UI.Image;

//Script that controls everything related to the main character, both in combat and outside of it.
//This script is being observed by GameController to know when there is a fight event.
public class PlayerController : MonoBehaviour
{
    //declared variables
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
        
        //getting the player state and the rigidbody 2d
        playerStateList = GetComponent<PlayerStateList>();
        rb2d = GetComponent<Rigidbody2D>();

        //getting the input from the character creation scene
        string savedName = PlayerPrefs.GetString("UserInput", "");
        if (savedName.Equals(""))
        {
            savedName = "John";
        }
        playerName = savedName;

        //setting the hp to max at the start of the game
        currentHP = maxHP;
        healthBar.SetMaxHealth(maxHP);
    }

    // method to set the game paused
    public void OnPause()
    {
        gamePaused = true;
    }

    // method to set the game resumed
    public void OnResume()
    {
        gamePaused = false;
    }


    public void Update()
    {
        //pausing actions if the game is paused
        if (gamePaused == false)
        {
            //pausing actions if the game is in battlemode
            if (!battleSystem.activeSelf)
            {
                //calling the function chekGround to enable the jump
                CheckGround checkGround = GetComponent<CheckGround>();
                bool check = checkGround.isGrounded();

                //getting the movements inputs
                GetInputs();

                //resetting the jump counter 
                resetJumpVaribles(check);

                //moving the character depending on the inputs
                Move();

                //flipping the character to the left or right
                Flip();

                //Jump method
                Jump(check);

                //heal character method
                if (Input.GetKeyDown(KeyCode.H) && currentHealCount < maxHeals && Time.time > lastHealTime + healCooldown)
                {
                    HealCharacter();
                }

                //limitating the fall speed to avoid weird behaviours
                if (rb2d.velocity.y < maxFallSpeed)
                {
                    rb2d.velocity = new Vector2(rb2d.velocity.x, maxFallSpeed);
                }

            }
        }
    }

    /**
     * This function heals the character with potions (out of combat)
     *
     * @param none
     */
    void HealCharacter()
    {
        //register the last time you used the healing button (in time in order to make a cooldown)
        lastHealTime = Time.time;

        //how many times the player healed
        currentHealCount++;

        //Healing the character + calling the healing text management function
        currentHP = maxHP;
        healTextFollow.HealCharacter();
    }

    /**
     * store the player inputs to later use
     *
     * @param none
     */
    void GetInputs()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
    }

    /**
     * This function boost the character stats.
     *
     * @param none
     */
    public void levelUpCharacter()
    {
        //we store the max hp from before
        float hpBefore = maxHP;
        //we update the last multiplier.
        statsMultiplier = statsMultiplier + 0.1f;

        //we multiply our stats to apply the boost
        damage = 5 * statsMultiplier;
        maxHP = 15 * statsMultiplier;

        //we round the last stats to avoid too much decimals (only 1)
        damage = Mathf.Round(damage * 10f) / 10f;
        maxHP = Mathf.Round(maxHP * 10f) / 10f;

        //we recover the difference in HP for the player
        float difference = maxHP - hpBefore;
        currentHP += difference;
    }

    /**
     * This function applies the inputs stored from GetInputs method in order to move the character
     *
     * @param none
     */
    private void Move()
    {
        rb2d.velocity = new Vector2(speed * xAxis, rb2d.velocity.y);
    }


    /**
     * This function detects if we hitted an enemy to enter the battle mode
     *
     * @param Collision2D collision //the enemy the character has collided with
     */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //We check if the collision has the tag "enemy" in order to apply the logic
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyCollision = collision.gameObject;

            //with this method we start the battle
            BattleScript = battleSystem.GetComponent<BattleSystem>();
            BattleScript.HandleCollision(enemyCollision);

            enemyEncounter();
        }
    }


    /**
     * This function flips the character to the left or right depending on the inputs taken
     *
     * @param none
     */
    void Flip()
    {
        if(xAxis < 0)
        {
            transform.localScale = new Vector2(0.7f, transform.localScale.y);
        }
        else if(xAxis > 0)
        {
            transform.localScale = new Vector2(-0.7f, transform.localScale.y);
        }
    }


    /**
     * This function makes the character jump or doubleJump depending on the status unlocked
     *
     * @param bool check //This entry comes from the groundcheck method
     */
    private void Jump(bool check)
    {
        //here we reset if the character is doublejumping or not
        if(check && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }

        //here we manage the jump itself
        if (Input.GetButtonDown("Jump"))
        {
            //the first one comes for the first jump
            if (check)
            {
                // First jump
                rb2d.velocity = new Vector2(rb2d.velocity.x, jump);
                doubleJump = true; //enable a double jump
            }
            //checking if we unlocked the doublejump and if we come from the first jump and not the second
            else if (doubleJump && doubleJumpUnlocked)
            {
                // Double jump
                rb2d.velocity = new Vector2(rb2d.velocity.x, jump);
                doubleJump = false; // disable double jump
            }
        }

        //depending on the pressed time of the space bar the character will jump more or less

        if (Input.GetButtonUp("Jump") && rb2d.velocity.y > 0f)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y * 0.5f);
        }
    }

    /**
     * This function resets our jump variables
     *
     * @param bool check //This entry comes from the groundcheck method
     */
    void resetJumpVaribles(bool check)
    {
        //changes the state of the player to no jumping
        if (check)
        {
            playerStateList.jumping = false;
        }
    }

    /**
     * This function allows the character to take damage from the enemies in combat
     *
     * @param float damage //This entry comes from the damage the enemy inflicts
     * 
     * 
     * @return bool true/false  //This will let us know if the character is dead
     */
    public bool ReceiveDamage(float damage)
    {
        //changing the hp
        currentHP -= damage;
        healthBar.SetHealth(currentHP);

        //check the character's death
        if (currentHP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /**
     * This function allows the character to heal in combat
     *
     * @param float heal //This entry comes from the heal the character produces
     * 
     * 
     */
    public void heal(float heal)
    {
        currentHP += heal;

        //we make sure that we don't surpass the maximum HP we have
        if(currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        healthBar.SetHealth(currentHP);

    }

}
