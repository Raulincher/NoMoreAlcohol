using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class PauseController : MonoBehaviour
{
    public UnityEvent GamePaused;
    public UnityEvent GameOn;
    public GameObject pauseMenu;
    public Button resume;
    private bool isPaused;
    private bool buttonPressed = false;

    void Start()
    {
        pauseMenu.SetActive(false);
        if (resume != null)
        {
            resume.onClick.AddListener(() => buttonPressed = true);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || buttonPressed)
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
                GamePaused.Invoke();
            }
            else { 

                pauseMenu.SetActive(false);
                Time.timeScale = 1;
                GameOn.Invoke();

            }

            buttonPressed = false;
        }
    }
}
