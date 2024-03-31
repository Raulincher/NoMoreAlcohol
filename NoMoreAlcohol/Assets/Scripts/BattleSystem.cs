using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


//Script que controla todo lo relacionado con el combate.
//Este script esta siendo observado por GameController para así saber cuando hay que terminar la pelea y quien es el ganador.
public enum BattleState {START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject EnemyPrefab;
    public Transform EnemyBattleStation;
    public BattleState state;
    Enemy enemyInfo;
    GameObject enemy, player;
    PlayerController playerInfo;
    public BattleHUD BattleHuds;

    public event Action<bool> OnBattleOver;
    public event Action Run;

    public void StartBattle()
    {
        StartCoroutine(SetUpBattle());
    }

    //set de la batalla de momento solo hay un enemigo disponible el cual solo hace un ataque
    public IEnumerator SetUpBattle()
    {
        state = BattleState.START;
        Debug.Log("set up");
        Vector3 spawnPosition = new Vector3(18f, 136.5f, -1);
        enemy = Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
        enemyInfo = enemy.GetComponent<Enemy>();
        player = Instantiate(PlayerPrefab);
        playerInfo = player.GetComponent<PlayerController>();


        BattleHuds.SetPlayerHud(playerInfo.PlayerName, playerInfo.MaxHP, playerInfo.CurrentHP);
        BattleHuds.SetEnemyHud(enemyInfo.EnemyName, enemyInfo.MaxHP, enemyInfo.CurrentHP);

        yield return new WaitForSeconds(2f);
        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        Debug.Log("ataque");
        bool isDead = enemyInfo.ReceiveDamage(playerInfo.Damage);

        BattleHuds.SetEnemyHP(enemyInfo.CurrentHP);

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            Destroy(enemy);
            Destroy(player);
            OnBattleOver(true);

        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator PlayerRun()
    {
        yield return new WaitForSeconds(2f);
        Run();
        Destroy(enemy);
        Destroy(player);
    }

    IEnumerator PlayerTrick()
    {
        playerInfo.heal(playerInfo.Damage);

        BattleHuds.SetPlayerHP(playerInfo.CurrentHP);

        yield return new WaitForSeconds(2f);
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    
    IEnumerator EnemyTurn()
    {
        Debug.Log("turno enemigo");
        yield return new WaitForSeconds(1f);
        bool isDead = playerInfo.ReceiveDamage(enemyInfo.Damage);
        BattleHuds.SetPlayerHP(playerInfo.CurrentHP);
        if (isDead)
        {
            state = BattleState.LOST;
            Destroy(enemy);
            Destroy(player);
            OnBattleOver(false);

        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void PlayerTurn()
    {
        Debug.Log("mi turno");
    }


    public void OnAttackButton()
    {
        Debug.Log("toco boton atk");
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerAttack());
    }

    public void OnTrickButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerTrick());
    }

    public void OnRunButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerRun());
    }

}
