using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

//Script that saves our input in the character creation scene
public class InputSave : MonoBehaviour
{
    //declaring our variables
    public TMP_InputField inputField;
    public Button saveButton;


    void Start()
    {
        //if our field is not null and our save button neither we put and addeventlistener in the save button
        if (inputField != null && saveButton != null)
        {
            saveButton.onClick.AddListener(InputSaveMethod);
        }

    }


    /**
     * Method to save our character name
     *
     * @param none
     */
    void InputSaveMethod()
    {
        string userInput = inputField.text;

        //if the entry is greater than 10 we cut it to prevent visual error in the battle huds
        if (userInput.Length > 10)
        {
            userInput = userInput.Substring(0, 10);
        }

        //function that helps us saving our string
        PlayerPrefs.SetString("UserInput", userInput);
        PlayerPrefs.Save();
    }
}
