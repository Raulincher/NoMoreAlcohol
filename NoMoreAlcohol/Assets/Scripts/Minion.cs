using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : Enemy
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
}
