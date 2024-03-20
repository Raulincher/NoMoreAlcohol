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

    public void SetEnemyHud(Enemy enemy)
    {
        EnemyNameTextMesh = EnemyName.GetComponent<TextMeshProUGUI>();
        EnemyNameTextMesh.text = enemy.EnemyName;
        HealthBarEnemy.maxValue = enemy.MaxHP;
        HealthBarEnemy.value = enemy.CurrentHP;
    }

    public void SetPlayerHud(Player player)
    {
        PlayerNameTextMesh = PlayerName.GetComponent<TextMeshProUGUI>();
        PlayerNameTextMesh.text = player.PlayerName;
        HealthBarPlayer.maxValue = player.MaxHP;
        HealthBarPlayer.value = player.CurrentHP;

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
