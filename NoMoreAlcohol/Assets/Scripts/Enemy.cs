using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public string EnemyName;
    public int Damage;

    public int MaxHP;
    public int CurrentHP;

    public HealthBar HealthBar;

    private void Start()
    {
        CurrentHP = MaxHP;
        HealthBar.SetMaxHealth(MaxHP);
    }


    public bool ReceiveDamage(int Damage)
    {
        CurrentHP -= Damage;
        HealthBar.SetHealth(CurrentHP);

        if(CurrentHP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

}
