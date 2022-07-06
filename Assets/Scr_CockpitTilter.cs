using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_CockpitTilter : MonoBehaviour
{
    public Vector3 RotateTo;
    public Vector3 CurrentRotation;

    // Update is called once per frame
    void Update()
    {
        RotateTo =  Vector3.Lerp(RotateTo, Vector3.zero, Time.deltaTime * 5);
        CurrentRotation = Vector3.Lerp(CurrentRotation,RotateTo, Time.deltaTime * 5);
        transform.rotation = Quaternion.Euler(CurrentRotation);
    }
}
