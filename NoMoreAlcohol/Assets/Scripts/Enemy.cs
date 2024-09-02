using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public string enemyName;
    public float damage;

    public float maxHP;
    public float currentHP;

    public HealthBar healthBar;

    private void Start()
    {
        currentHP = maxHP;
        healthBar.SetMaxHealth(maxHP);
    }


    public bool ReceiveDamage(float damage)
    {
        currentHP -= damage;
        healthBar.SetHealth(currentHP);

        if(currentHP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public virtual void Ability() { }
    public virtual void Ability2() { }
}
