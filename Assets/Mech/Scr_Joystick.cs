using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Joystick : MonoBehaviour
{
    [SerializeField] Scr_MechMovement Movement;
    [SerializeField] Scr_MechLook Look;
    [SerializeField] Animator LAnim;
    Vector2 LLerp;

    [SerializeField] Animator RAnim;
    Vector2 RLerp;

    // Update is called once per frame
    void Update()
    {
        LLerp = Vector2.Lerp(LLerp,Movement.GetHorizontalInput(), Time.deltaTime * 5);
        LAnim.SetFloat("Forward",LLerp.y);
        LAnim.SetFloat("Right",LLerp.x);

        RLerp = Vector2.Lerp(RLerp,Look.GetInput() * 0.1f, Time.deltaTime * 5);
        RAnim.SetFloat("Forward",RLerp.y);
        RAnim.SetFloat("Right",RLerp.x);
    }
}
