using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class BattleHUD : MonoBehaviour
{
    public GameObject enemyName;
    public GameObject enemyTurn;
    public GameObject enemyAction;
    public GameObject playerName;
    public GameObject playerTurn;
    public GameObject playerTrick;
    public GameObject playerAttack;
    TextMeshProUGUI enemyNameTextMesh;
    TextMeshProUGUI enemyActionTextMesh;
    TextMeshProUGUI enemyTurnTextMesh;
    TextMeshProUGUI playerNameTextMesh;
    TextMeshProUGUI playerTurnTextMesh;
    TextMeshProUGUI playerTrickTextMesh;
    TextMeshProUGUI playerAttackTextMesh;
    public Slider healthBarPlayer;
    public Slider healthBarEnemy;

    public void SetEnemyHud(string enemyNameString, float maxHP, float currentHP)
    {
        enemyNameTextMesh = enemyName.GetComponent<TextMeshProUGUI>();
        enemyNameTextMesh.text = enemyNameString;
        healthBarEnemy.maxValue = maxHP;
        healthBarEnemy.value = currentHP;
    }

    public void SetPlayerHud(string playerNameString, float maxHP, float currentHP)
    {
        playerNameTextMesh = playerName.GetComponent<TextMeshProUGUI>();
        playerNameTextMesh.text = playerNameString;
        healthBarPlayer.maxValue = maxHP;
        healthBarPlayer.value = currentHP;

    }
    public void SetPlayerHP(float hp)
    {
        if(hp < 0)
        {
            hp = 0;
        }
        healthBarPlayer.value = hp;
    }
    public void SetEnemyHP(float hp)
    {
        if (hp < 0)
        {
            hp = 0;
        }
        healthBarEnemy.value = hp;
    }


    public void PlayerTurn(string playerName)
    {
        playerTurnTextMesh = playerTurn.GetComponent<TextMeshProUGUI>();
        playerTurnTextMesh.text = playerName + " Turn.";
    }
    public void PlayerTurnOn()
    {
        playerTurn.SetActive(true);

    }
    public void PlayerTurnOff()
    {
        playerTurn.SetActive(false);
    }

    public void PlayerTrick(string playerName, float damage)
    {
        playerTrickTextMesh = playerTrick.GetComponent<TextMeshProUGUI>();
        playerTrickTextMesh.text = playerName + " used Trick, " + playerName + " healed " + damage + " points of life.";
    }

    public void PlayerTrickOn()
    {
        playerTrick.SetActive(true);
    }

    public void PlayerTrickOff()
    {
        playerTrick.SetActive(false);
    }


    public void PlayerAttack(string playerName, float damage)
    {
        playerAttackTextMesh = playerAttack.GetComponent<TextMeshProUGUI>();
        playerAttackTextMesh.text = playerName + " used Fight, the enemy received " + damage + " points of damage.";
    }

    public void PlayerAttackOn()
    {
        playerAttack.SetActive(true);
    }

    public void PlayerAttackOff()
    {
        playerAttack.SetActive(false);
    }


    public void EnemyTurn(string enemyName)
    {
        enemyTurnTextMesh = enemyTurn.GetComponent<TextMeshProUGUI>();
        enemyTurnTextMesh.text = enemyName + " Turn.";
    }

    public void EnemyTurnOn()
    {
        enemyTurn.SetActive(true);
    }

    public void EnemyTurnOff()
    {
        enemyTurn.SetActive(false);
    }

    public void EnemyAction(string enemyName, float damage, int abilityNumber)
    {
        enemyActionTextMesh = enemyAction.GetComponent<TextMeshProUGUI>();

        if (enemyName.Equals("Nightmare Puppeter"))
        {

            switch (abilityNumber)
            {
                case 1:
                    enemyActionTextMesh.text = enemyName + " used sharp claws to attack inflicts " + damage + " to player.";
                    break;
                case 2:
                    enemyActionTextMesh.text = enemyName + " used the power of shadows to heal itself, it heals " + damage + " points of damage.";
                    break;
                default:
                    enemyActionTextMesh.text = enemyName + " screams ferocily inflicting " + damage + " points of damage to player.";
                    break;

            }

        }else if (enemyName.Equals("Demon Lord"))
        {

            switch (abilityNumber)
            {
                case 1:
                    enemyActionTextMesh.text = enemyName + " slash the player inflicting " + damage + " points of damage.";
                    break;
                case 2:
                    enemyActionTextMesh.text = enemyName + " use hellfire to heal its wounds, " + damage + " points of damage were healed.";
                    break;
                default:
                    enemyActionTextMesh.text = enemyName + " imbues its sword in fire, his attack rises for the rest of the battle.";
                    break;

            }
        }
        else
        {
            switch (abilityNumber)
            {
                case 1:

                    int behaviour = UnityEngine.Random.Range(0, 100);

                    if (behaviour <= 33)
                    {
                        enemyActionTextMesh.text = enemyName + " headbutts the player inflicting " + damage + " points of damage";
                    }
                    else if (behaviour > 33 && behaviour <= 66)
                    {
                        enemyActionTextMesh.text = enemyName + " bites the player inflicting " + damage + " points of damage";
                    }
                    else
                    {
                        enemyActionTextMesh.text = enemyName + " scratch the player inflicting " + damage + " points of damage";
                    }

                    break;
                default:
                    enemyActionTextMesh.text = enemyName + " uses the power of the darkness to heal, " + enemyName + " heals " + damage + " points";
                    break;

            }

        }
    }

    public void EnemyActionOn()
    {
        enemyAction.SetActive(true);
    }

    public void EnemyActionOff()
    {
        enemyAction.SetActive(false);
    }


    public void PlayerLevelUp()
    {
        playerAttackTextMesh = playerAttack.GetComponent<TextMeshProUGUI>();
        playerAttackTextMesh.text = "After Killing that enemy you suddenly feel stronger, your stats went up.";
    }

}
