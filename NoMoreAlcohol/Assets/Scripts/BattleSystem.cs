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


//Script que controla todo lo relacionado con el combate.
//Este script esta siendo observado por GameController para así saber cuando hay que terminar la pelea y quien es el ganador.
public enum BattleState {START, PLAYERTURN, PLAYERTRICK, PLAYERATTACK, ENEMYTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{

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
    public event Action<bool> OnBattleOver;

    public void StartBattle()
    {
        StartCoroutine(SetUpBattle());
    }

    public void HandleCollision(GameObject collidedObject)
    {
        if (collidedObject != null)
        {
            enemy = collidedObject;
            enemyInfo = collidedObject.GetComponent<Enemy>();
        }
    }

    //set de la batalla de momento solo hay un enemigo disponible el cual solo hace un ataque
    public IEnumerator SetUpBattle()
    {
        state = BattleState.START;

        player = GameObject.FindGameObjectWithTag("Player");


        playerInfo = player.GetComponent<PlayerController>();
        
        Vector3 spawnPosition = new Vector3(17.8f, 137.3f, 10);
  
        enemy.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);

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
        
        Instantiate(enemy, spawnPosition, Quaternion.identity);

        battleHuds.SetPlayerHud(playerInfo.playerName, playerInfo.maxHP, playerInfo.currentHP);
        battleHuds.SetEnemyHud(enemyInfo.enemyName, enemyInfo.maxHP, enemyInfo.currentHP);
        battleHuds.EnemyTurnOff();
        battleHuds.PlayerTurnOff();
        battleHuds.PlayerAttackOff();
        battleHuds.PlayerTrickOff();
        battleHuds.EnemyActionOff();

        yield return new WaitForSeconds(0.5f);
        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        battleHuds.PlayerTurnOff();
        battleHuds.PlayerAttackOn();
        battleHuds.PlayerAttack(playerInfo.playerName, playerInfo.damage);
        state = BattleState.PLAYERATTACK;


        bool isDead = enemyInfo.ReceiveDamage(playerInfo.damage);

        battleHuds.SetEnemyHP(enemyInfo.currentHP);
        
        yield return new WaitForSeconds(3f);

        if (isDead)
        {
            state = BattleState.WON;
            if (enemy.name.Contains("tp"))
            {
                Destroy(enemy);
                CloneErase();
                OnBattleOver(true);
                SceneManager.LoadScene("Ending1");


            }
            else if (enemy.name.Contains("lord"))
            {
                Destroy(enemy);
                CloneErase();
                OnBattleOver(true);
                SceneManager.LoadScene("Ending2");

            }
            else
            {
                Destroy(enemy);
                CloneErase();
                battleHuds.PlayerLevelUp();
                yield return new WaitForSeconds(3f);
                playerInfo.levelUpCharacter();
                OnBattleOver(true);
            }


        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }


    IEnumerator PlayerTrick()
    {
        battleHuds.PlayerTurnOff();
        battleHuds.PlayerTrickOn();
        battleHuds.PlayerTrick(playerInfo.playerName, playerInfo.damage);
        state = BattleState.PLAYERTRICK;
        playerInfo.heal(playerInfo.damage);

        battleHuds.SetPlayerHP(playerInfo.currentHP);

        yield return new WaitForSeconds(3f);
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    
    IEnumerator EnemyTurn()
    {
        battleHuds.PlayerTrickOff();
        battleHuds.PlayerAttackOff();
        battleHuds.EnemyTurnOn();
        battleHuds.EnemyTurn(enemyInfo.enemyName);
        yield return new WaitForSeconds(2f);
        battleHuds.EnemyTurnOff();
        battleHuds.EnemyActionOn();
        int behaviour = UnityEngine.Random.Range(0, 100);
        bool isDead = false;
        int abilityFlag = 0;
        if (enemyInfo.enemyName.Equals("Nightmare Puppeter"))
        {
            if (behaviour <= 10)
            {
                enemyInfo.Ability2();
                isDead = playerInfo.ReceiveDamage(enemyInfo.damage);
                battleHuds.SetPlayerHP(playerInfo.currentHP);
                enemyInfo.damage = enemyInfo.damage / 2f;
                abilityFlag = 0;
            }
            else if (behaviour > 10 && behaviour <= 40)
            {
                enemyInfo.Ability();
                abilityFlag = 2;
            }
            else
            {
                abilityFlag = 1;
                isDead = playerInfo.ReceiveDamage(enemyInfo.damage);
                battleHuds.SetPlayerHP(playerInfo.currentHP);
            }
        }
        else if(enemyInfo.enemyName.Equals("Demon Lord"))
        {
            if (behaviour <= 20)
            {

                abilityFlag = 2;
                enemyInfo.Ability();
            }
            else if (behaviour > 20 && behaviour <= 50)
            {
                abilityFlag = 0;
                enemyInfo.Ability2();
            }
            else
            {
                abilityFlag = 1;
                isDead = playerInfo.ReceiveDamage(enemyInfo.damage);
                battleHuds.SetPlayerHP(playerInfo.currentHP);
            }
        }
        else
        {
            if (behaviour <= 40)
            {
                abilityFlag = 0;
                Debug.Log("entro cura");
                Debug.Log(abilityFlag);
                enemyInfo.Ability();
            }
            else
            {
                abilityFlag = 1;
                isDead = playerInfo.ReceiveDamage(enemyInfo.damage);
                battleHuds.SetPlayerHP(playerInfo.currentHP);
            }
        }

        battleHuds.EnemyAction(enemyInfo.enemyName, enemyInfo.damage, abilityFlag);


        yield return new WaitForSeconds(4f);

        if (isDead)
        {
            state = BattleState.LOST;
            Destroy(enemy);
            OnBattleOver(true);
            SceneManager.LoadScene("Ending3");


        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void PlayerTurn()
    {
        battleHuds.EnemyActionOff();
        battleHuds.PlayerTurnOn();
        battleHuds.PlayerTurn(playerInfo.playerName);

    }


    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerAttack());
        DeselectButton();
    }

    public void OnTrickButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerTrick());
        DeselectButton();
    }

    private void DeselectButton()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }


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
