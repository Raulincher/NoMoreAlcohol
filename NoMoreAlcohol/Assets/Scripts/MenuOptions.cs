using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//script with all the posible actions of the buttons in the game
public class MenuOptions : MonoBehaviour
{
    public AudioSource audioSource;

    //we use this to let the audio sound and end whne we touch a button that makes us leaves the scene
    private IEnumerator PlaySoundAndExecute(System.Action action)
    {
        audioSource.Play();

        while (audioSource.isPlaying)
        {
            yield return null;
        }

        action?.Invoke();
    }

    //Method to change to the tavern scene (main game)
    public void PlayGame()
    {
        StartCoroutine(PlaySoundAndExecute(() => SceneManager.LoadScene("Taberna")));
    }

    //Method to change to the character creation scene
    public void CharacterCreation()
    {
        StartCoroutine(PlaySoundAndExecute(() => SceneManager.LoadScene("CharacterName")));
    }

    //Method to change to the intro scene
    public void Intro()
    {
        StartCoroutine(PlaySoundAndExecute(() => SceneManager.LoadScene("Intro")));
    }

    //Method to quit the game
    public void QuitGame()
    {
        StartCoroutine(PlaySoundAndExecute(Application.Quit));
    }

}
