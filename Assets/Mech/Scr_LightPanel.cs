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

    [SerializeField] Scr_HudLight OffLightsHud;
    [SerializeField] Scr_HudLight LightsHud;
    [SerializeField] Scr_HudLight FloodLightsHud;

    [SerializeField] Scr_Power Power;
    float PowerDrain = 0;


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

        OffLightsHud.IsOn = true;
        LightsHud.IsOn = false;
        FloodLightsHud.IsOn = false;
        PowerDrain = 0;
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

        OffLightsHud.IsOn = false;
        LightsHud.IsOn = true;
        FloodLightsHud.IsOn = false;
        PowerDrain = 3;
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

        OffLightsHud.IsOn = false;
        LightsHud.IsOn = false;
        FloodLightsHud.IsOn = true;
        PowerDrain = 7;
    }

    void Update()
    {
        Power.Power -= Time.deltaTime * PowerDrain;
    }
}
