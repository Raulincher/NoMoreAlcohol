using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonLord : Enemy
{
    float statsMultiplier = 1;
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
        statsMultiplier = statsMultiplier + 0.2f;
        damage = damage + 0.2f;
    }
}
