using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Scr_Button : MonoBehaviour
{
    public UnityEvent myEvent;

    public void OnButtonPress()
    {
        myEvent.Invoke();
    }
}
