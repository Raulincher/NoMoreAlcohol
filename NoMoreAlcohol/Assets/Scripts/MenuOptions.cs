using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("Taberna");
    }

    public void CharacterCreation()
    {
        SceneManager.LoadScene("CharacterName");
    }

}
