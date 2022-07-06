using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_LightPanel : MonoBehaviour
{
    [SerializeField] AudioSource AS; 
    [SerializeField] AudioClip OffSound; 
    [SerializeField] AudioClip OnSound; 
    [SerializeField] AudioClip HighSound; 
    
    enum LightState
    {
        Off,
        On,
        High,
    }

   [SerializeField] GameObject Lights;
   [SerializeField] GameObject FloodLights;

   [SerializeField] LightState CurrentLight;

    public void LightOff()
    {
        if (CurrentLight == LightState.Off)
        {
            return;
        }
        CurrentLight = LightState.Off;
        Lights.SetActive(false);
        FloodLights.SetActive(false);
        AS.PlayOneShot(OffSound);
    }

    public void LightOn()
    {
        if (CurrentLight == LightState.On)
        {
            return;
        }
       CurrentLight = LightState.On; 
        Lights.SetActive(true);
        FloodLights.SetActive(false);
        AS.PlayOneShot(OnSound);
    }

    public void LightHigh()
    {
        if (CurrentLight == LightState.High)
        {
            return;
        }
        CurrentLight = LightState.High;
        Lights.SetActive(false);
        FloodLights.SetActive(true);
        AS.PlayOneShot(HighSound);
    }
}
