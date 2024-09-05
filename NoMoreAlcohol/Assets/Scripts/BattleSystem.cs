using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;



//We enumerate our states in the battle to use them in the turns management
public enum BattleState {START, PLAYERTURN, PLAYERTRICK, PLAYERATTACK, ENEMYTURN, WON, LOST}

//Script that controls everything related to combat.
//This script is being watched by GameController to know when to end the fight.
public class BattleSystem : MonoBehaviour
{
    //variables set up
    [Header("Player")]
    public GameObject player;

    [Header("Enemy")]
    public GameObject EnemyPrefab;
    public Transform EnemyBattleStation;
    Enemy enemyInfo;
    GameObject enemy;
    PlayerController playerInfo;


    [Header("Battle")]
    public BattleHUD battleHuds;
    public BattleState state;
    public event Action OnBattleOver;

    /**
     * This function starts the coroutine for set up battle
     *
     * @param none
     */
    public void StartBattle()
    {
        //We start a coroutine to manage our setup battle
        StartCoroutine(SetUpBattle());
    }

    /**
     * This function get the info of the collided enemy we got in the playerController
     *
     * @param collidedObject //Collided enemy
     */
    public void HandleCollision(GameObject collidedObject)
    {
        //detects if the collidedObject is null
        if (collidedObject != null)
        {
            enemy = collidedObject;
            enemyInfo = collidedObject.GetComponent<Enemy>();
        }
    }

    //We setup all the battle
    public IEnumerator SetUpBattle()
    {
        //we set the battle state to start
        state = BattleState.START;

        //we get the player controller script
        player = GameObject.FindGameObjectWithTag("Player");
        playerInfo = player.GetComponent<PlayerController>();
        
        Vector3 spawnPosition = new Vector3(17.8f, 137.3f, 10);
        enemy.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);

        //we relocate all the enemies in the battle stations correctly (this is just a correction)
        if (enemy.name.Contains("lord"))
        {
            enemy.transform.localScale = new Vector3(4f, 4f, 4f);
            spawnPosition = new Vector3(17.8f, 139f, 10);
        }
        if (enemy.name.Contains("tp"))
        {
            enemy.transform.localScale = new Vector3(5.15f, 5f, 5f);
            spawnPosition = new Vector3(18.05f, 138.81f, 10);
        }
        if (enemy.name.Contains("Dog"))
        {
            enemy.transform.localScale = new Vector3(3f, 3f, 3f);
            spawnPosition = new Vector3(18.5f, 137.6f, 10);
        }
        if (enemy.name.Contains("pot"))
        {
            enemy.transform.localScale = new Vector3(4f, 4f, 4f);
            spawnPosition = new Vector3(17.8f, 138.5f, 10);
        }
        if (enemy.name.Contains("Frog"))
        {
            enemy.transform.localScale = new Vector3(3f, 3f, 3f);
            spawnPosition = new Vector3(17.8f, 137.7f, 10);
        }
        if (enemy.name.Contains("calabaza"))
        {
            spawnPosition = new Vector3(17.87f, 137f, 10);
        }

        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();

        rb.bodyType = RigidbodyType2D.Static;
        
        //we instantiate a copy of our enemy. It will appear in the fight
        Instantiate(enemy, spawnPosition, Quaternion.identity);

        //here we set up our battlehud
        battleHuds.SetPlayerHud(playerInfo.playerName, playerInfo.maxHP, playerInfo.currentHP);
        battleHuds.SetEnemyHud(enemyInfo.enemyName, enemyInfo.maxHP, enemyInfo.currentHP);
        battleHuds.EnemyTurnOff();
        battleHuds.PlayerTurnOff();
        battleHuds.PlayerAttackOff();
        battleHuds.PlayerTrickOff();
        battleHuds.EnemyActionOff();

        //we wait 0.5 second to make sure all is set up
        yield return new WaitForSeconds(0.5f);

        //and then we start our player turn
        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }


    /**
     * This function will help us manage our player attack action 
     *
     * @param none
     */

    IEnumerator PlayerAttack()
    {

        //we set up the message zone to be sure about showing the correect message in the battle
        battleHuds.PlayerTurnOff();
        battleHuds.PlayerAttackOn();
        battleHuds.PlayerAttack(playerInfo.playerName, playerInfo.damage);

        //we change the state of the battle to indicate our player attack
        state = BattleState.PLAYERATTACK;

        // we check if the enemy is dead after receiving the damage
        bool isDead = enemyInfo.ReceiveDamage(playerInfo.damage);

        //we set the current hp of our enemy
        battleHuds.SetEnemyHP(enemyInfo.currentHP);
        
        //this will help us showing our message for 3 seconds letting the player procces the info in the turn
        yield return new WaitForSeconds(3f);


        //here we check if our enemy is dead with the flag from before
        if (isDead)
        {
            //knowing that our enemy is dead we check which kind of monster we killed
            state = BattleState.WON;
            if (enemy.name.Contains("tp"))
            {
                //we enter if we defeated the main boss of the game, this part will show us the first ending
                Destroy(enemy);
                CloneErase();
                OnBattleOver();
                SceneManager.LoadScene("Ending1");


            }
            else if (enemy.name.Contains("lord"))
            {

                //we enter if we defeated the secret boss of the game, this part will show us the second ending

                Destroy(enemy);
                CloneErase();
                OnBattleOver();
                SceneManager.LoadScene("Ending2");

            }
            else
            {

                //we enter if we defeated a normal enemy, here we will wait 3 second to let the player know that he/she raised a level
                Destroy(enemy);
                CloneErase();
                battleHuds.PlayerLevelUp();
                yield return new WaitForSeconds(3f);
                playerInfo.levelUpCharacter();
                OnBattleOver();
            }


        }
        else
        {
            //we proceed with the combat if we didn't kill our enemy
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    /**
     * This function will help us manage our player trick action (healing at the moment)
     *
     * @param none
     */
    IEnumerator PlayerTrick()
    {
        //we set up our battlehud to show the correct text
        battleHuds.PlayerTurnOff();
        battleHuds.PlayerTrickOn();
        battleHuds.PlayerTrick(playerInfo.playerName, playerInfo.damage);

        //change to our state to indicate we are doing the trick
        state = BattleState.PLAYERTRICK;

        //healing the same amount of damage our character deals
        playerInfo.heal(playerInfo.damage);


        //refreshing our life variable
        battleHuds.SetPlayerHP(playerInfo.currentHP);

        //waiting 3 second to let the player process the actions in the turn with the texts from before
        yield return new WaitForSeconds(3f);

        //starting enemy turn
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }


    /**
     * This function will help us manage our enemy turn
     *
     * @param none
     */
    IEnumerator EnemyTurn()
    {
        //setting up the texts to show that it is our enemy turn
        DeselectButton();
        battleHuds.PlayerTrickOff();
        battleHuds.PlayerAttackOff();
        battleHuds.EnemyTurnOn();
        battleHuds.EnemyTurn(enemyInfo.enemyName);


        //time to let the player its the enmy turn
        yield return new WaitForSeconds(2f);

        //turniong on the text for the enemy action
        battleHuds.EnemyTurnOff();
        battleHuds.EnemyActionOn();

        //here we decided which thing will the enemy do (randomly)
        int behaviour = UnityEngine.Random.Range(0, 100);

        //setting up the flags
        bool isDead = false;
        int abilityFlag = 0;

        //knowing which type of enemy is attacking
        if (enemyInfo.enemyName.Equals("Nightmare Puppeter"))
        {
            //heare we can see the behaviour of our enemies divided in 3 abilities for the bosses and 2 for the minions
            if (behaviour <= 10)
            {
                //crit ability, the functionality is to set up, temporarily, our enemy damage x2
                enemyInfo.Ability2();
                isDead = playerInfo.ReceiveDamage(enemyInfo.damage);
                battleHuds.SetPlayerHP(playerInfo.currentHP);
                enemyInfo.damage = enemyInfo.damage / 2f;
                abilityFlag = 0;
            }
            else if (behaviour > 10 && behaviour <= 40)
            {
                //healing ability, this will allow our monster to heal itself
                enemyInfo.Ability();
                abilityFlag = 2;
            }
            else
            {
                //Normal attack. this will allow our monster to deal damage to our character
                abilityFlag = 1;
                isDead = playerInfo.ReceiveDamage(enemyInfo.damage);
                battleHuds.SetPlayerHP(playerInfo.currentHP);
            }
        }
        else if(enemyInfo.enemyName.Equals("Demon Lord"))
        {
            if (behaviour <= 20)
            {
                //healing ability, this will allow our monster to heal itself
                abilityFlag = 2;
                enemyInfo.Ability();
            }
            else if (behaviour > 20 && behaviour <= 50)
            {
                //raise attack ability, this will allow our monster to raise its attack for x1.2 for the rest of the battle
                //it will grow 0.2 every time the monster use it -> x1.2 -> x1.4 -> x1.6 -> ... calculated from its base attack

                abilityFlag = 0;
                enemyInfo.Ability2();
            }
            else
            {
                //Normal attack. this will allow our monster to deal damage to our character
                abilityFlag = 1;
                isDead = playerInfo.ReceiveDamage(enemyInfo.damage);
                battleHuds.SetPlayerHP(playerInfo.currentHP);
            }
        }
        else
        {
            if (behaviour <= 30)
            {
                //healing ability, this will allow our monster to heal itself
                abilityFlag = 0;
                enemyInfo.Ability();
            }
            else
            {
                //Normal attack. this will allow our monster to deal damage to our character
                abilityFlag = 1;
                isDead = playerInfo.ReceiveDamage(enemyInfo.damage);
                battleHuds.SetPlayerHP(playerInfo.currentHP);
            }
        }

        //we set up the text for our enemy action
        battleHuds.EnemyAction(enemyInfo.enemyName, enemyInfo.damage, abilityFlag);

        //waiting 4 seconds to let the player know what happened in the enemy action
        yield return new WaitForSeconds(4f);

        //checking if our character died
        if (isDead)
        {

            //we show the last ending
            state = BattleState.LOST;
            Destroy(enemy);
            OnBattleOver();
            SceneManager.LoadScene("Ending3");


        }
        else
        {

            //we continue in the battle
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }


    /**
     * This function will help us manage our player turn
     *
     * @param none
     */
    void PlayerTurn()
    {
        //we set our player turn text
        battleHuds.EnemyActionOff();
        battleHuds.PlayerTurnOn();
        battleHuds.PlayerTurn(playerInfo.playerName);

    }

    /**
     * This function will help us manage the click on the attack button
     *
     * @param none
     */
    public void OnAttackButton()
    {

        //checking if the state of the battle equals the turn of the player
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerAttack());

        //this will let us activate our hover button after we pressed it on our turn
        DeselectButton();
    }


    /**
     * This function will help us manage the click on the trick button
     *
     * @param none
     */
    public void OnTrickButton()
    {

        //checking if the state of the battle equals the turn of the player
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerTrick());

        //this will let us activate our hover button after we pressed it on our turn
        DeselectButton();
    }

    /**
     * This function will help us activate our hover button after we pressed it on our turn
     *
     * @param none
     */
    private void DeselectButton()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }

    /**
     * This function erase the copy of the enemy we create in the set up (we used the one that searches all the copies)
     *
     * @param none
     */
    void CloneErase()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            if (enemy.name.Contains("(Clone)"))
            {
                Destroy(enemy);
            }
        }
    }

}
