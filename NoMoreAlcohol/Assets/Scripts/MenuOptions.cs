using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    public AudioSource audioSource;
    private IEnumerator PlaySoundAndExecute(System.Action action)
    {
        audioSource.Play();

        while (audioSource.isPlaying)
        {
            yield return null;
        }

        action?.Invoke();
    }

    public void PlayGame()
    {
        StartCoroutine(PlaySoundAndExecute(() => SceneManager.LoadScene("Taberna")));
    }

    public void CharacterCreation()
    {
        StartCoroutine(PlaySoundAndExecute(() => SceneManager.LoadScene("CharacterName")));
    }

    public void Intro()
    {
        StartCoroutine(PlaySoundAndExecute(() => SceneManager.LoadScene("Intro")));
    }

    public void QuitGame()
    {
        StartCoroutine(PlaySoundAndExecute(Application.Quit));
    }

}
