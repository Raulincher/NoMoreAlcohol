using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * NightmarePuppeteer is a child class of enemy
 */
public class NightmarePuppeteer : Enemy
{

    /**
     * Method to apply the first ability of the NightmarePuppeteer.(heal)
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
     * Method to apply the first ability of the NightmarePuppeteer.(crit)
     * 
     * @param none
     */
    public override void Ability2()
    {
        damage = damage * 2;
    }
}
