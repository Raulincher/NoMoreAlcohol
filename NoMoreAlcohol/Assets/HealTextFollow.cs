using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealTextFollow : MonoBehaviour
{
    public TextMeshProUGUI healingText;
    private int currentHealCount = 0;

    void Start()
    {
        healingText.gameObject.SetActive(false);
    }


    public void HealCharacter()
    {
        currentHealCount++;

        healingText.gameObject.SetActive(true);
        healingText.text = "All your life has been restored! (" + (3 - currentHealCount) +" out of 3 uses remaining.)";

        Invoke("HideHealingText", 8f);
    }


    void HideHealingText()
    {
        // Hide the healing text after a short delay
        healingText.gameObject.SetActive(false);
    }
}
