using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightmarePuppeteer : Enemy
{
    public override void Ability()
    {
        currentHP += damage;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        healthBar.SetHealth(currentHP);
    }


    public override void Ability2()
    {
        damage = damage * 2;
    }
}
