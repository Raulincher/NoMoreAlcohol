using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFX : MonoBehaviour
{

    public AudioSource buttonAudio;
    public AudioClip hover;
    public AudioClip click;


    public void HoverSound()
    {
        buttonAudio.PlayOneShot(hover);
    }

    public void ClickSound()
    {
        buttonAudio.PlayOneShot(click);
    }

}
