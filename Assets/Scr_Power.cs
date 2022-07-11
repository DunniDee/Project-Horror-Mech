using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Power : MonoBehaviour
{
    public bool HasPower = true;
    bool WasPower;
    [SerializeField] Scr_HudLight[] AllLights;
    [SerializeField] Light PilotLight;
    [SerializeField] Light EmergencyLight;
    [SerializeField] Renderer ScreenRend;
    [SerializeField] Material ScreenMat;
    float ScreenMatLerp = 1300;
    [SerializeField] float EmergencySystemDelay;
    float EmergencySystemDelayTimer;

    public float Power = 100;
    [SerializeField] bool PowerGenerating;
    [SerializeField] Scr_PowerBar PowerBar;

    bool HasDied;
    [SerializeField] bool CanRestart;
    [SerializeField] bool PowerSequenceA = true;
    [SerializeField] bool PowerSequenceB = true;
    [SerializeField] bool PowerSequenceC = true;
    [SerializeField] bool PowerSequenceD = true;
    [SerializeField] Scr_HudLight EmergencyBulb;
    [SerializeField] Scr_HudLight LightA;
    [SerializeField] Scr_HudLight LightB;
    [SerializeField] Scr_HudLight LightC;
    [SerializeField] Scr_HudLight LightD;

    float FlashTimer;

    // Start is called before the first frame update
    void Start()
    {
        AllLights = GameObject.FindObjectsOfType<Scr_HudLight>();
        ScreenMat = ScreenRend.sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        if (PowerGenerating)
        {
            Power += Time.deltaTime * 10;
        }
        Power = Mathf.Clamp(Power,0,100);

        PowerBar.Energy = Power;

        if (Power <= 2.5f && !HasDied)
        {
            FlashLightsOff();
            HasPower = false;
            PowerGenerating = false;
            PowerSequenceA = false;
            PowerSequenceB = false;
            PowerSequenceC = false;
            PowerSequenceD = false;
            HasDied = true;
            CanRestart = false;
        }

        if (PowerSequenceA && PowerSequenceB && PowerSequenceC && PowerSequenceD)
        {
            PowerOn();
        }

        if (HasPower != WasPower)
        {
            ToggleLights();
        }
        WasPower = HasPower;

        if (HasPower)
        {
            ScreenMatLerp = Mathf.Lerp(ScreenMatLerp, 1300,Time.deltaTime * 2);
            PilotLight.intensity = Mathf.Lerp(PilotLight.intensity, 100, Time.deltaTime);
            EmergencyBulb.NoPower = true;
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
                EmergencyLight.enabled = true;
                EmergencyLight.intensity = Mathf.Lerp(EmergencyLight.intensity, 25, Time.deltaTime * 0.5f);
                CanRestart = true;
                LightA.NoPower = false;
                LightB.NoPower = false;
                LightC.NoPower = false;
                LightD.NoPower = false;
                EmergencyBulb.NoPower = false;

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
            EmergencyBulb.NoPower = true;
            LightA.IsOn = true;
            LightB.IsOn = true;
            LightC.IsOn = true;
            LightD.IsOn = true;
        }
        else
        {
            EmergencySystemDelayTimer = EmergencySystemDelay;

            LightA.IsOn = true;
            LightB.IsOn = true;
            LightC.IsOn = true;
            LightD.IsOn = true;
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

        void FlashLightsOff()
    {
        bool toggle = true;
        for (int i = 0; i < 8; i++)
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

    void PowerOn()
    {
        HasPower = true;
        PowerGenerating = true;
        HasDied = false;
        if (Power<5)
        {
            Power=10;
        }

        LightA.NoPower = true;
        LightB.NoPower = true;
        LightC.NoPower = true;
        LightD.NoPower = true;
    }

    public void PowerA()
    {
        if (CanRestart)
        {
            PowerSequenceA = true;
            LightA.IsOn = false;
        }
    }

    public void PowerB()
    {
        if (CanRestart)
        {   
            PowerSequenceB = true;
            LightB.IsOn = false;
        }
    }

    public void PowerC()
    {
        if (CanRestart)
        {
            PowerSequenceC = true;
            LightC.IsOn = false;
        }
    }

    public void PowerD()
    {
        if (CanRestart)
        { 
            PowerSequenceD = true;
            LightD.IsOn = false;
        }
    }

}
