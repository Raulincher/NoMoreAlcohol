using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Script that controls the sounds our buttons produces
public class ButtonFX : MonoBehaviour
{
    //here we set up our variables
    public AudioSource buttonAudio;
    public AudioClip hover;
    public AudioClip click;

    //button that will be produced when hovering
    public void HoverSound()
    {
        buttonAudio.PlayOneShot(hover);
    }

    //button that will be produced when clicking
    public void ClickSound()
    {
        buttonAudio.PlayOneShot(click);
    }

}
