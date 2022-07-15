using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_ProximityScanner : MonoBehaviour
{
    [SerializeField] Scr_HudLightBlinker[] Lights;
    [SerializeField] Transform[] ScannerPos;
    [SerializeField] LayerMask CreatureMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        for (int i = 0; i < 8; i++)
        {
            CheckScanner(ScannerPos[i], i);
        }
    }


    void CheckScanner(Transform Pos, int BlinkIndex)
    {
        RaycastHit hit;
        if (Physics.Raycast(Pos.position, Pos.forward, out hit, 10, CreatureMask))
        {
            Lights[BlinkIndex].IsBlinking = true;
            Lights[BlinkIndex].BlinkTime = hit.distance * 0.1f;
        }
        else
        {
            Lights[BlinkIndex].IsBlinking = false;
        }
    }
}
