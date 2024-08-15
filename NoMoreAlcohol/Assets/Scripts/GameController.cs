using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { FreeRoam, Battle }

//Script que controla los eventos del juego, sigue el modelo observer
public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] BattleSystem battleSystem;
    [SerializeField] Camera worldCamera;
    [SerializeField] GameObject auxCamera; 

    GameState state;

    void Start()
    {
        playerController.EnemyEncounter += StartBattle;
        battleSystem.OnBattleOver += EndBattle;
    }

    void StartBattle()
    {
        state = GameState.Battle;
        battleSystem.gameObject.SetActive(true);
        worldCamera.gameObject.SetActive(false);
        auxCamera.SetActive(false);
        battleSystem.StartBattle();

    }

    void EndBattle(bool won)
    {
        state = GameState.FreeRoam;
        battleSystem.gameObject.SetActive(false);
        worldCamera.gameObject.SetActive(true);
        auxCamera.SetActive(true);

    }

    private void Update()
    {
        if (state == GameState.FreeRoam)
        {
            playerController.Update();

        }else if (state == GameState.Battle)
        {
            battleSystem.SetUpBattle();
        }
    }

}
