using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_MouseLook : MonoBehaviour
{
    [SerializeField] float SensitivityX = 8;
    [SerializeField] float SensitivityY = 8;

    [SerializeField] float DefaultFOV = 60;
    [SerializeField] float LockFOV = 50;
    float CurrentFof;

    [SerializeField] Camera LookCam;
    [SerializeField] Transform CamSwivel;

    public bool IsLocked;

    Vector2 MouseInput;
    [SerializeField] Vector2 LookClamp;
    Vector2 LookRotation;

    // Start is called before the first frame update
    void Start()
    {
        //to lock in the centre of window
        Cursor.lockState = CursorLockMode.Locked;
        //to hide the curser
        Cursor.visible = false;

        CurrentFof = DefaultFOV;
    }

    // Update is called once per frame
    void Update()
    {    
        if (IsLocked)
        {
            LookRotation.x += MouseInput.x * Time.deltaTime * 0.1f;
            LookRotation.y -= MouseInput.y * Time.deltaTime * 0.1f;

            LookRotation.x = Mathf.Clamp(LookRotation.x, -LookClamp.x,LookClamp.x);
            LookRotation.y = Mathf.Clamp(LookRotation.y, -LookClamp.y,LookClamp.y);

            CurrentFof = Mathf.Lerp(CurrentFof, LockFOV, Time.deltaTime * 5);
        }
        else
        {
            LookRotation.x += MouseInput.x * Time.deltaTime;
            LookRotation.y -= MouseInput.y * Time.deltaTime;

            LookRotation.x = Mathf.Clamp(LookRotation.x, -LookClamp.x,LookClamp.x);
            LookRotation.y = Mathf.Clamp(LookRotation.y, -LookClamp.y,LookClamp.y);

            CurrentFof = Mathf.Lerp(CurrentFof, DefaultFOV, Time.deltaTime * 5);
        }

        if (IsLocked)
        {
            LookRotation.x = Mathf.Lerp(LookRotation.x, 0, Time.deltaTime * 5);
            LookRotation.y = Mathf.Lerp(LookRotation.y, 0, Time.deltaTime * 5);
        }

        LookCam.fieldOfView = CurrentFof;

        CamSwivel.localRotation = Quaternion.Euler(0,LookRotation.x,0);
        LookCam.transform.localRotation = Quaternion.Euler(LookRotation.y,0,0);
    }

    public void RecieveInput(Vector2 _mouseInput)
    {
        MouseInput.x = _mouseInput.x;
        MouseInput.y = _mouseInput.y;
    }

    public void Click()
    {
        Debug.Log("Click");
    }
}
