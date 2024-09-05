using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script that controls the healthbar

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        //we set the slider itself interactable = false to avoid the user modifyng it visually
        slider.interactable = false;
    }
    
    
    /**
     * Method to set our max health
     *
     * @param health   //float we receive to set our max health
     */

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }


    /**
     * Method to set health to the number we receive
     *
     * @param health   //float we receive to set our health to its value
     */
    public void SetHealth(float health)
    {
        slider.value = health;
    }

}
