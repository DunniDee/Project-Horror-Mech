using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_HudLightBlinker : Scr_HudLight
{
    public float BlinkTime;
    public bool IsBlinking;

    [SerializeField] AudioSource AS;
    [SerializeField] AudioClip BlinkSound;
    [SerializeField] float volume;

    float Timer;

    // Update is called once per frame
    new void Update()
    {
        CheckLight();

        if (!NoPower)
        {
            if (IsBlinking)
            {
                if (Timer >= 0)
                {
                    Timer-=Time.deltaTime;
                }
                else
                {
                    Timer = BlinkTime;
                    IsOn = !IsOn;
                    AS.PlayOneShot(BlinkSound,volume);
                }
            }
            else
            {
                IsOn = false;
            }
        }
    }
}
