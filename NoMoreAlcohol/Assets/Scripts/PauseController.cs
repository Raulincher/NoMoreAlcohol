using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//Script that handles the pause and the resume of the game
public class PauseController : MonoBehaviour
{

    //declaring variables
    public UnityEvent GamePaused;
    public UnityEvent GameOn;
    public GameObject pauseMenu;
    public Button resume;
    private bool isPaused;
    private bool buttonPressed = false;

    void Start()
    {
        //setting up variables
        pauseMenu.SetActive(false);
        if (resume != null)
        {
            resume.onClick.AddListener(() => buttonPressed = true);
        }
    }
    void Update()
    {
        //detecting if we pressed the pause/resume key or if we pressed the resume button in the game
        if (Input.GetKeyDown(KeyCode.Escape) || buttonPressed)
        {
            //flag that tells us if we are paused or not
            isPaused = !isPaused;

            //checking if we are paused
            if (isPaused)
            {
                //pausing the game and showing the menu
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
                GamePaused.Invoke();
            }
            else {

                //resuming the game and hiding the menu
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
                GameOn.Invoke();

            }

            buttonPressed = false;
        }
    }
}
