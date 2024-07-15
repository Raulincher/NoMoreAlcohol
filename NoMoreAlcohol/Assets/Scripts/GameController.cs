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

    GameState state;

    void Start()
    {
        //playerController.OnEncountered += StartBattle;
        battleSystem.OnBattleOver += EndBattle;
        battleSystem.Run += Escape;
    }

    void StartBattle()
    {
        state = GameState.Battle;
        battleSystem.gameObject.SetActive(true);
        worldCamera.gameObject.SetActive(false);
        battleSystem.StartBattle();

    }

    void Escape()
    {
        state = GameState.FreeRoam;
        battleSystem.gameObject.SetActive(false);
        worldCamera.gameObject.SetActive(true);
    }

    void EndBattle(bool won)
    {
        state = GameState.FreeRoam;
        battleSystem.gameObject.SetActive(false);
        worldCamera.gameObject.SetActive(true);

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
