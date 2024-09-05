using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { FreeRoam, Battle }

//Script that controls game events, follows the observer model
public class GameController : MonoBehaviour
{
    //varible setups
    [SerializeField] PlayerController playerController;
    [SerializeField] BattleSystem battleSystem;
    [SerializeField] Camera worldCamera;
    [SerializeField] GameObject auxCamera; 

    GameState state;


    void Start()
    {
        //here we register the method StartBattle as a handler of the enemyEncounter event in playerController.
        playerController.enemyEncounter += StartBattle;

        //here we register the method EndBattle as a handler of the OnBattleOver event in battleSystem.
        battleSystem.OnBattleOver += EndBattle;
    }

    /**
     * Method to handle the startBattle
     *
     * @param none
     */
    void StartBattle()
    {
        //we set the game state to battle
        state = GameState.Battle;

        //we set to true our battle system where we handle all the fight
        battleSystem.gameObject.SetActive(true);

        //we set to false our game cameras to activate our camera battle in the battlesystem
        worldCamera.gameObject.SetActive(false);
        auxCamera.SetActive(false);

        //we start battle from the battleSystem
        battleSystem.StartBattle();

    }


    /**
     * Method to handle the EndBattle
     *
     * @param none
     */
    void EndBattle()
    {
        //we set the game state to our map zone
        state = GameState.FreeRoam;

        //we set to false our battle system where we handle all the fight
        battleSystem.gameObject.SetActive(false);

        //we set to true our game cameras to activate our map view.
        worldCamera.gameObject.SetActive(true);
        auxCamera.SetActive(true);

    }

    private void Update()
    {
        //allows us to let the player move or not depending if its fighting or not.
        if (state == GameState.FreeRoam)
        {
            playerController.Update();

        }else if (state == GameState.Battle)
        {
            battleSystem.SetUpBattle();
        }
    }

}
