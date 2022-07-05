using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_MechLook : MonoBehaviour
{
    [SerializeField] float SensitivityX = 8;
    [SerializeField] float SensitivityY = 8;
    [SerializeField] float SwivelSpeed = 8;

    [SerializeField] Transform LookCam;
    [SerializeField] Transform MechAgent;

    public bool IsLocked;

    Vector2 MouseInput;
    [SerializeField] Vector2 LookClamp;
    Vector2 LookRotation;
    Vector2 MechRotation;

    // Start is called before the first frame update
    void Start()
    {
        //to lock in the centre of window
        Cursor.lockState = CursorLockMode.Locked;
        //to hide the curser
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {    
        if (MouseInput.sqrMagnitude > SwivelSpeed * SwivelSpeed)
        {
            MouseInput = MouseInput.normalized * SwivelSpeed;
        }

        if (!IsLocked)
        {
            LookRotation.x += MouseInput.x * Time.deltaTime;

            if (LookRotation.x != 0)
            {
                MechRotation.y = Mathf.Lerp(MechRotation.y, SwivelSpeed * MechRotation.x, Time.deltaTime * 10);
            }
            LookRotation.x += MechRotation.y * Time.deltaTime;
            LookRotation.y -= MouseInput.y * Time.deltaTime;



            LookRotation.y = Mathf.Clamp(LookRotation.y, -LookClamp.y,LookClamp.y);
        }

        MechAgent.localRotation= Quaternion.Euler(0,LookRotation.x,0);
        LookCam.localRotation= Quaternion.Euler(LookRotation.y,0,0);
    }

    public void RecieveInput(Vector2 _mouseInput, Vector2 mechRotation)
    {
        MouseInput.x = _mouseInput.x;
        MouseInput.y = _mouseInput.y;

        MechRotation.x = mechRotation.x;
        Debug.Log(MechRotation);
    }

    public Vector2 GetInput()
    {
        if (!IsLocked)
        {
            return MouseInput;
        }
        else
        {
            return Vector2.zero;
        }
    }
}
