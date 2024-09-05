using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Script that controls the text when we use the heal potion

public class HealTextFollow : MonoBehaviour
{
    //declared variables
    [Header("Heal text settings")]
    public TextMeshProUGUI healingText;
    private int currentHealCount = 0;

    void Start()
    {
        healingText.gameObject.SetActive(false);
    }


    public void HealCharacter()
    {
        //counter to take control of the healings
        currentHealCount++;

        //healing text control
        healingText.gameObject.SetActive(true);
        healingText.text = "All your life has been restored! (" + (3 - currentHealCount) +" out of 3 uses remaining.)";

        //invoke the method to set the heal text to false
        Invoke("HideHealingText", 8f);
    }


    void HideHealingText()
    {
        // Hide the healing text after a short delay
        healingText.gameObject.SetActive(false);
    }
}
