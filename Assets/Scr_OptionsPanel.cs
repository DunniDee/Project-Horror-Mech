using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_OptionsPanel : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform Hinge;
    public bool IsOpen = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOpen)
        {
            Hinge.localRotation = Quaternion.Lerp(Hinge.localRotation, Quaternion.Euler(145,0,0), Time.deltaTime * 2);
        }
        else
        {
            Hinge.localRotation = Quaternion.Lerp(Hinge.localRotation, Quaternion.Euler(0,0,0), Time.deltaTime * 2);
        }
    }

    public void ToggleOpen()
    {
        IsOpen = !IsOpen;
    }
}
