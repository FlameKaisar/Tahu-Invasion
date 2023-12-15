using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1, sfx2, sfx3, sfx4;

    public void clickButton()
    {
        src.clip = sfx1;
        src.Play();
    }

    public void hoverButton()
    {
        src.clip = sfx2;
        src.Play();
    }

}
