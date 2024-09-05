using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * DemonLord is a child class of enemy
 */
public class DemonLord : Enemy
{
    float statsMultiplier = 1;

    /**
     * Method to apply the first ability of the demon lord if it is called
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

    /**
     * Method to apply the second ability of the demon lord if it is called
     * 
     * 
     * @param none
     */
    public override void Ability2()
    {
        damage = 9.5f;
        statsMultiplier = statsMultiplier + 0.2f;
        damage = damage + 0.2f;
    }
}
