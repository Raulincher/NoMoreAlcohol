using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    public GameObject interactText;  // Asigna aqu� el objeto de texto "Presiona E"


    void Start()
    {
        interactText.SetActive(false);  // El texto est� oculto al inicio
    }

    public void ShowInteractText()
    {
        interactText.SetActive(true);
    }

    public void HideInteractText()
    {
        interactText.SetActive(false);
    }
}
