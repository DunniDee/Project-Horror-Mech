using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PowerBar : MonoBehaviour
{
    [Range(0,100)]
    public float Energy;

    [SerializeField] Scr_HudLight[] Lights;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        foreach (var Light in Lights)
        {
            Light.IsOn = false;
        }

        int length = Mathf.RoundToInt(Energy/10);
        for (int i = 0; i < length; i++)
        {
            Lights[i].IsOn = true;
        }
    }
}
