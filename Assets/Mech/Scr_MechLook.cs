using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_MechLook : MonoBehaviour
{
    [SerializeField] float SensitivityX = 8;
    [SerializeField] float SensitivityY = 8;
    public float SwivelSpeed = 8;

    [SerializeField] Transform LookCam;
    [SerializeField] Transform MechAgent;

    [SerializeField] AudioSource RotateAS;

    public bool IsLocked;

    public bool IsRotating;

    Vector2 MouseInput;
    [SerializeField] Vector2 LookClamp;
    Vector2 LookRotation;
    Vector2 MechRotation;

    [SerializeField] Scr_Power Power;

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
        if (MouseInput != Vector2.zero && !IsLocked || MechRotation.x != 0)
        {
            RotateAS.volume = Mathf.Lerp( RotateAS.volume, 1, Time.deltaTime * 5);
            RotateAS.pitch = Mathf.Lerp( RotateAS.pitch, 1.25f, Time.deltaTime * 2);
            IsRotating = true;
        }
        else
        {
            RotateAS.volume = Mathf.Lerp( RotateAS.volume, 0, Time.deltaTime * 5);
            RotateAS.pitch = Mathf.Lerp( RotateAS.pitch, 0.8f, Time.deltaTime * 2);
            IsRotating = false;
        }



        if (MouseInput.sqrMagnitude > SwivelSpeed * SwivelSpeed)
        {
            MouseInput = MouseInput.normalized * SwivelSpeed;
        }

        if (LookRotation.x != 0)
        {
            MechRotation.y = Mathf.Lerp(MechRotation.y, SwivelSpeed * MechRotation.x, Time.deltaTime * 10);
        }
        LookRotation.x += MechRotation.y * Time.deltaTime;

        if (!IsLocked)
        {
            LookRotation.x += MouseInput.x * Time.deltaTime;
            LookRotation.y -= MouseInput.y * Time.deltaTime;



            LookRotation.y = Mathf.Clamp(LookRotation.y, -LookClamp.y,LookClamp.y);
        }

        if (!Power.HasPower)
        {
            LookRotation.y = Mathf.Lerp(LookRotation.y, LookClamp.y, Time.deltaTime);
        }

        MechAgent.localRotation= Quaternion.Euler(0,LookRotation.x,0);
        LookCam.localRotation= Quaternion.Euler(LookRotation.y,0,0);
    }

    public void RecieveInput(Vector2 _mouseInput, Vector2 mechRotation)
    {
        if (Power.HasPower)
        {
            MouseInput.x = _mouseInput.x;
            MouseInput.y = _mouseInput.y;

            MechRotation.x = mechRotation.x;
        }
        else
        {
            MouseInput.x = 0;
            MouseInput.y = 0;

            MechRotation.x = 0;
        }
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
