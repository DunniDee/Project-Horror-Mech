using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_MechManager : MonoBehaviour
{
    [SerializeField] Scr_MouseLook MouseLook;
    [SerializeField] Scr_MechLook MechLook;
    [SerializeField] Transform MechAgent;

    public bool IsColldingWall;

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

    bool CheckWalls()
    {
        bool Check = false;

        Debug.DrawRay(MechAgent.position + Vector3.up * 3, MechAgent.forward * 3, Color.green);
        if (Physics.Raycast(MechAgent.position + Vector3.up * 3, MechAgent.forward, 3, LayerMask.NameToLayer("Ground")))
        {
            Check = true;
        }

        return Check;
    }

    private void Update() 
    {
        IsColldingWall = CheckWalls();
    }
}
