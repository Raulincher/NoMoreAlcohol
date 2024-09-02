using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class InputSave : MonoBehaviour
{
    public TMP_InputField inputField;
    public Button saveButton;

    void Start()
    {
        Debug.Log("Input guardado en PlayerPrefs: 1" );


        if (inputField != null && saveButton != null)
        {
            saveButton.onClick.AddListener(InputSaveMethod);
        }

    }

    void InputSaveMethod()
    {
        string userInput = inputField.text;

        if (userInput.Length > 10)
        {
            userInput = userInput.Substring(0, 10);
        }

        Debug.Log("User input saved: " + userInput);

        PlayerPrefs.SetString("UserInput", userInput);
        PlayerPrefs.Save();
    }
}
