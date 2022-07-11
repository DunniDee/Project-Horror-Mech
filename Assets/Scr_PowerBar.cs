using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PowerBar : MonoBehaviour
{
    [Range(0,100)]
    public float Energy;

    [SerializeField] Scr_HudLight[] Lights;
    float BarLerp;
    void Update()
    {
        BarLerp = Mathf.Lerp(BarLerp, Energy, Time.deltaTime * 10);
        foreach (var Light in Lights)
        {
            Light.IsOn = false;
        }

        int length = Mathf.RoundToInt(BarLerp/10);
        for (int i = 0; i < length; i++)
        {
            Lights[i].IsOn = true;
        }
    }
}
