using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public GameObject EnemyName;
    public GameObject PlayerName;
    TextMeshProUGUI EnemyNameTextMesh;
    TextMeshProUGUI PlayerNameTextMesh;
    public Slider HealthBarPlayer;
    public Slider HealthBarEnemy;

    public void SetEnemyHud(string enemyName, int MaxHP, int CurrentHP)
    {
        EnemyNameTextMesh = EnemyName.GetComponent<TextMeshProUGUI>();
        EnemyNameTextMesh.text = enemyName;
        HealthBarEnemy.maxValue = MaxHP;
        HealthBarEnemy.value = CurrentHP;
    }

    public void SetPlayerHud(string playerName, int MaxHP, int CurrentHP)
    {
        PlayerNameTextMesh = PlayerName.GetComponent<TextMeshProUGUI>();
        PlayerNameTextMesh.text = playerName;
        HealthBarPlayer.maxValue = MaxHP;
        HealthBarPlayer.value = CurrentHP;

    }
    public void SetPlayerHP(int hp)
    {
        if(hp < 0)
        {
            hp = 0;
        }
        HealthBarPlayer.value = hp;
    }
    public void SetEnemyHP(int hp)
    {
        if (hp < 0)
        {
            hp = 0;
        }
        HealthBarEnemy.value = hp;
    }


}
