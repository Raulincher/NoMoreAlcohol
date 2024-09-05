using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Father class enemy, here we manage the things all the enmies have in common like the life or the damage
public class Enemy : MonoBehaviour
{
    //declaring our stats
    [Header("Stats")]
    public string enemyName;
    public float damage;
    public float maxHP;
    public float currentHP;
    public HealthBar healthBar;

    private void Start()
    {
        //setting up the enemy life
        currentHP = maxHP;
        healthBar.SetMaxHealth(maxHP);
    }

    /**
     * This function manage the damage the enmy receive
     *
     * @param damage  //float that indicates the amount of damage the enemy takes
     * 
     * 
     * @return bool 
     */
    public bool ReceiveDamage(float damage)
    {
        currentHP -= damage;
        healthBar.SetHealth(currentHP);

        //checkin if the enemy is dead
        if(currentHP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //reference to the ability the enemies have, the childs will override them
    public virtual void Ability() { }
    public virtual void Ability2() { }
}
