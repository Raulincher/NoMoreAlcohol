using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public enum BattleState {START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject EnemyPrefab;
    public Transform EnemyBattleStation;
    public BattleState state;
    Enemy enemyInfo;
    PlayerController playerInfo;
    public BattleHUD BattleHuds;

    // Start is called before the first frame update
    void Start()
    { 
        StartCoroutine(SetUpBattle());  
    }

    public IEnumerator SetUpBattle()
    {
        state = BattleState.START;
        Debug.Log("set up");
        Vector3 spawnPosition = new Vector3(19f, 136f, 0);
        GameObject Enemy = Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
        enemyInfo = Enemy.GetComponent<Enemy>();
        GameObject Player = Instantiate(PlayerPrefab);
        playerInfo = Player.GetComponent<PlayerController>();

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
            EndBattle();

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
    }

    IEnumerator PlayerTrick()
    {
        yield return new WaitForSeconds(2f);
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
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }
    void EndBattle()
    {
        //if(state == BattleState.WON)
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
