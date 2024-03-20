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
    Player playerInfo;
    public BattleHUD BattleHuds;

    // Start is called before the first frame update
    void Start()
    { 
        state = BattleState.START;
        StartCoroutine(SetUpBattle());  
    }

    IEnumerator SetUpBattle()
    {
        GameObject Enemy = Instantiate(EnemyPrefab, EnemyBattleStation);
        enemyInfo = Enemy.GetComponent<Enemy>();
        GameObject Player = Instantiate(PlayerPrefab);
        playerInfo = Player.GetComponent<Player>();

        BattleHuds.SetPlayerHud(playerInfo);
        BattleHuds.SetEnemyHud(enemyInfo);

        yield return new WaitForSeconds(2f);
        state = BattleState.PLAYERTURN;
        PlayerTurn();

    }

    IEnumerator PlayerAttack()
    {
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

    }


    public void OnAttackButton()
    {
        if(state != BattleState.PLAYERTURN)
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
