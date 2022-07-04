using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_MechManager : MonoBehaviour
{
    [SerializeField] Scr_MouseLook MouseLook;
    [SerializeField] Scr_MechLook MechLook;

    bool IsLocked = false;
    public void ToggleLock()
    {
        IsLocked = !IsLocked;

        if (IsLocked)
        {
            MouseLook.IsLocked = false;
            MechLook.IsLocked = true;
        }
        else
        {
            MouseLook.IsLocked = true;
            MechLook.IsLocked = false;
        }
    }
}
