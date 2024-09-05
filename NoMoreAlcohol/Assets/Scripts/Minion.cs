using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * minion is a child class of enemy
 */
public class Minion : Enemy
{

    /**
     * Method to apply the first ability of the minion (heal)
     * 
     * 
     * 
     * @param none
     */
    public override void Ability()
    {
        currentHP += damage;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        healthBar.SetHealth(currentHP);
    }
}
