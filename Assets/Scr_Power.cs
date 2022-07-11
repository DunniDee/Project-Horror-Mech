using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Power : MonoBehaviour
{
    [SerializeField] bool HasPower = true;
    bool WasPower;
    [SerializeField] Scr_HudLight[] AllLights;
    [SerializeField] Light PilotLight;
    [SerializeField] Light EmergencyLight;
    [SerializeField] Renderer ScreenRend;
    [SerializeField] Material ScreenMat;
    float ScreenMatLerp = 1300;
    [SerializeField] float EmergencySystemDelay;
    float EmergencySystemDelayTimer;

    // Start is called before the first frame update
    void Start()
    {
        AllLights = GameObject.FindObjectsOfType<Scr_HudLight>();
        ScreenMat = ScreenRend.sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        if (HasPower != WasPower )
        {
            ToggleLights();
        }
        WasPower = HasPower;

        if (HasPower)
        {
            ScreenMatLerp = Mathf.Lerp(ScreenMatLerp, 1300,Time.deltaTime);
            PilotLight.intensity = Mathf.Lerp(PilotLight.intensity, 100, Time.deltaTime);
        }
        else
        {
            ScreenMatLerp = Mathf.Lerp(ScreenMatLerp, 0,Time.deltaTime);
            PilotLight.intensity = Mathf.Lerp(PilotLight.intensity, 0, Time.deltaTime);
            if (EmergencySystemDelayTimer > 0)
            {
                EmergencySystemDelayTimer -= Time.deltaTime;
            }
            else
            {
                EmergencyLight.intensity = Mathf.Lerp(EmergencyLight.intensity, 25, Time.deltaTime);
            }
            
        }
        ScreenMat.SetFloat("_Emmisive",ScreenMatLerp);
    }

    void ToggleLights()
    {
        foreach (var Light in AllLights)
        {
            Light.NoPower = !HasPower;
        }

        if (HasPower)
        {
            PilotLight.enabled = true;
            EmergencyLight.enabled = false;
            EmergencyLight.intensity = 0;
            FlashLights();
        }
        else
        {
            EmergencySystemDelayTimer = EmergencySystemDelay;
            EmergencyLight.enabled = true;

        }
    }

    void FlashLights()
    {
        bool toggle = true;
        for (int i = 0; i < 7; i++)
        {
            if (toggle)
            {
                Invoke("LightsOn", i * 0.075f);
            }
            else
            {
                Invoke("LightsOff", i * 0.075f);
            }

            toggle = !toggle;
        }
    }

    void LightsOn()
    {
        foreach (var Light in AllLights)
        {
            Light.NoPower = false;
        }
    }
    void LightsOff()
    {
        foreach (var Light in AllLights)
        {
            Light.NoPower = true;
        }
    }
}
