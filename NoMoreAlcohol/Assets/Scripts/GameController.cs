using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { FreeRoam, Battle }

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] BattleSystem battleSystem;
    [SerializeField] Camera worldCamera;

    GameState state;

    void Start()
    {
        playerController.OnEncountered += StartBattle;
    }

    void StartBattle()
    {
        state = GameState.Battle;
        battleSystem.gameObject.SetActive(true);
        worldCamera.gameObject.SetActive(false);

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
