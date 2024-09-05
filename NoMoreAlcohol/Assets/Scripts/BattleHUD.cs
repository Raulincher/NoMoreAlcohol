using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UIElements.UxmlAttributeDescription;


//Script that controls everything related to the battlehud shown in combat
//This script is called by the battlesystem to set it up
public class BattleHUD : MonoBehaviour
{
    //our variables
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


    /**
     * This function get the info of the enemy and sets up the encounter
     *
     * @param enemyNameString   //name of the enemy we fight
     * @param maxHP             //Max life of the enemy
     * @param currentHP         //Enemies life after receive/heal life
     * 
     */
    public void SetEnemyHud(string enemyNameString, float maxHP, float currentHP)
    {
        //setting the variables in text with the one we receive for the setup
        enemyNameTextMesh = enemyName.GetComponent<TextMeshProUGUI>();
        enemyNameTextMesh.text = enemyNameString;
        healthBarEnemy.maxValue = maxHP;
        healthBarEnemy.value = currentHP;
    }


    /**
     * This function get the info of the player and sets up the encounter
     *
     * @param enemyNameString   //name of the enemy we fight
     * @param maxHP             //Max life of the enemy
     * @param currentHP         //Enemies life after receive/heal life
     * 
     */
    public void SetPlayerHud(string playerNameString, float maxHP, float currentHP)
    {

        //setting the variables in text with the one we receive for the setup
        playerNameTextMesh = playerName.GetComponent<TextMeshProUGUI>();
        playerNameTextMesh.text = playerNameString;
        healthBarPlayer.maxValue = maxHP;
        healthBarPlayer.value = currentHP;

    }

    /**
     * This function sets the player HP for the encounter
     *
     * @param hp                //float that indicates our life at the start of the battle
     * 
     */
    public void SetPlayerHP(float hp)
    {
        //avoiding negative numbers
        if (hp < 0)
        {
            hp = 0;
        }
        healthBarPlayer.value = hp;
    }

    /**
     * This function sets the player HP for the encounter
     *
     * @param hp                //float that indicates our life at the start of the battle
     * 
     */
    public void SetEnemyHP(float hp)
    {
        //avoiding negative numbers
        if (hp < 0)
        {
            hp = 0;
        }
        healthBarEnemy.value = hp;
    }



    /**
     * Method that sets the player turn text
     *
     * @param playerName                //string that indicates our character name
     * 
     */
    public void PlayerTurn(string playerName)
    {
        playerTurnTextMesh = playerTurn.GetComponent<TextMeshProUGUI>();
        playerTurnTextMesh.text = playerName + " Turn.";
    }
    /**
     * Method that turns on the player turn text
     *
     * @param none
     * 
     */
    public void PlayerTurnOn()
    {
        playerTurn.SetActive(true);

    }
    /**
     * Method that turns off the player turn text
     *
     * @param none
     * 
     */
    public void PlayerTurnOff()
    {
        playerTurn.SetActive(false);
    }


    /**
     * Method that sets the player trick text
     *
     * @param playerName                //string that indicates our character name
     * @param damage                    //float that indicates our character damage(also the amount of healing)
     * 
     */
    public void PlayerTrick(string playerName, float damage)
    {
        playerTrickTextMesh = playerTrick.GetComponent<TextMeshProUGUI>();
        playerTrickTextMesh.text = playerName + " used Trick, " + playerName + " healed " + damage + " points of life.";
    }

    /**
     * Method that turns on the player trick text
     *
     * @param none
     * 
     */
    public void PlayerTrickOn()
    {
        playerTrick.SetActive(true);
    }


    /**
     * Method that turns off the player trick text
     *
     * @param none
     * 
     */

    public void PlayerTrickOff()
    {
        playerTrick.SetActive(false);
    }

    /**
     * Method that sets the player attack text
     *
     * @param playerName                //string that indicates our character name
     * @param damage                    //float that indicates our character damage(also the amount of healing)
     * 
     */
    public void PlayerAttack(string playerName, float damage)
    {
        playerAttackTextMesh = playerAttack.GetComponent<TextMeshProUGUI>();
        playerAttackTextMesh.text = playerName + " used Fight, the enemy received " + damage + " points of damage.";
    }

    /**
     * Method that turns on the player attack text
     *
     * @param none
     * 
     */
    public void PlayerAttackOn()
    {
        playerAttack.SetActive(true);
    }

    /**
     * Method that turns off the player attack text
     *
     * @param none
     * 
     */
    public void PlayerAttackOff()
    {
        playerAttack.SetActive(false);
    }

    /**
     * Method that sets the enemy turn text
     *
     * @param enemyName                 //string that indicates our enemy name
     * 
     */
    public void EnemyTurn(string enemyName)
    {
        enemyTurnTextMesh = enemyTurn.GetComponent<TextMeshProUGUI>();
        enemyTurnTextMesh.text = enemyName + " Turn.";
    }

    /**
     * Method that turns on the enemy turn text
     *
     * @param none
     * 
     */
    public void EnemyTurnOn()
    {
        enemyTurn.SetActive(true);
    }

    /**
     * Method that turns off the enemy turn text
     *
     * @param none
     * 
     */
    public void EnemyTurnOff()
    {
        enemyTurn.SetActive(false);
    }


    /**
     * Method that sets the enemy turn text
     *
     * @param enemyName                 //string that indicates our enemy name
     * @param damage                    //float that indicates our enemy damage
     * @param abilityNumber             //int that indicates the ability the enemy used
     * 
     */
    public void EnemyAction(string enemyName, float damage, int abilityNumber)
    {
        enemyActionTextMesh = enemyAction.GetComponent<TextMeshProUGUI>();

        //we compare our enemy names to know if we which type of ability we have
        if (enemyName.Equals("Nightmare Puppeter"))
        {
            //depending on the ability the enemy used we set one text or another
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
            //depending on the ability the enemy used we set one text or another
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
            //depending on the ability the enemy used we set one text or another
            switch (abilityNumber)
            {
                case 1:

                    int behaviour = UnityEngine.Random.Range(0, 100);

                    //this is the most common type of enemy so we prepare 3 different texts and set up one randomly
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


    /**
     * Method that turns on the enemy action text
     *
     * @param none
     * 
     */
    public void EnemyActionOn()
    {
        enemyAction.SetActive(true);
    }


    /**
     * Method that turns off the enemy action text
     *
     * @param none
     * 
     */
    public void EnemyActionOff()
    {
        enemyAction.SetActive(false);
    }

    /**
     * Method that set ups the player leveled up text
     *
     * @param none
     * 
     */
    public void PlayerLevelUp()
    {
        playerAttackTextMesh = playerAttack.GetComponent<TextMeshProUGUI>();
        playerAttackTextMesh.text = "After Killing that enemy you suddenly feel stronger, your stats went up.";
    }

}
