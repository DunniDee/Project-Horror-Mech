using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scr_MouseLook : MonoBehaviour
{
    [SerializeField] float SensitivityX = 8;
    [SerializeField] float SensitivityY = 8;

    [SerializeField] float DefaultFOV = 60;
    [SerializeField] float LockFOV = 50;

    [SerializeField] Image Crosshair;
    [SerializeField] Color CrosshairColor;
    [SerializeField] Color CrosshairSelectColor;
    Color CurrentCrosshairColor;

    float CurrentFof;

    [SerializeField] Camera LookCam;
    [SerializeField] Transform CamSwivel;
    [SerializeField] Scr_MechWeapons Weapons;
    public Vector2 LookTarget;
    public float LockLerpSpeed = 5;

    public bool IsLocked;
    public bool IsDead;

    Vector2 MouseInput;
    [SerializeField] Vector2 LookClamp;
    Vector2 LookRotation;


    public Scr_AmmoShell Shell;

    // Start is called before the first frame update
    void Start()
    {
        //to lock in the centre of window
        Cursor.lockState = CursorLockMode.Locked;
        //to hide the curser
        Cursor.visible = false;

        CurrentFof = DefaultFOV;
        CurrentCrosshairColor = CrosshairColor;
    }

    // Update is called once per frame
    void Update()
    {    
        CheckButton();

        if (IsDead)
        {
            LookRotation.x += MouseInput.x * SensitivityX * Time.deltaTime * 0.1f;
            LookRotation.y -= MouseInput.y * SensitivityY  * Time.deltaTime * 0.1f;

            LookRotation.x = Mathf.Clamp(LookRotation.x, -LookClamp.x,LookClamp.x);
            LookRotation.y = Mathf.Clamp(LookRotation.y, -LookClamp.y,LookClamp.y);

            LookRotation.x = Mathf.Lerp(LookRotation.x, LookTarget.x, Time.deltaTime * LockLerpSpeed);
            LookRotation.y = Mathf.Lerp(LookRotation.y, LookTarget.y, Time.deltaTime * LockLerpSpeed);

            CurrentFof = Mathf.Lerp(CurrentFof, DefaultFOV, Time.deltaTime * 5);

            Crosshair.color = Color.Lerp(Crosshair.color, new Color(0,0,0,0), Time.deltaTime  * 5);
        }
        else
        {
            if (IsLocked)
            {
                LookRotation.x += MouseInput.x * SensitivityX * Time.deltaTime * 0.1f;
                LookRotation.y -= MouseInput.y * SensitivityY  * Time.deltaTime * 0.1f;

                LookRotation.x = Mathf.Clamp(LookRotation.x, -LookClamp.x,LookClamp.x);
                LookRotation.y = Mathf.Clamp(LookRotation.y, -LookClamp.y,LookClamp.y);

                LookRotation.x = Mathf.Lerp(LookRotation.x, 0, Time.deltaTime * 5);
                LookRotation.y = Mathf.Lerp(LookRotation.y, 0, Time.deltaTime * 5);

                CurrentFof = Mathf.Lerp(CurrentFof, LockFOV, Time.deltaTime * 5);

                Crosshair.color = Color.Lerp(Crosshair.color, new Color(0,0,0,0), Time.deltaTime  * 5);
            }
            else
            {
                LookRotation.x += MouseInput.x * SensitivityX * Time.deltaTime;
                LookRotation.y -= MouseInput.y * SensitivityY * Time.deltaTime;

                LookRotation.x = Mathf.Clamp(LookRotation.x, -LookClamp.x,LookClamp.x);
                LookRotation.y = Mathf.Clamp(LookRotation.y, -LookClamp.y,LookClamp.y);

                CurrentFof = Mathf.Lerp(CurrentFof, DefaultFOV, Time.deltaTime * 5);

                Crosshair.color = Color.Lerp(Crosshair.color, CurrentCrosshairColor, Time.deltaTime  * 5);
            }
        }

        LookCam.fieldOfView = CurrentFof;

        CamSwivel.localRotation = Quaternion.Euler(0,LookRotation.x,0);
        LookCam.transform.localRotation = Quaternion.Euler(LookRotation.y,0,0);

        if (Shell != null)
        {
            Shell.FollowPoint = LookCam.transform.position + LookCam.transform.forward * 0.75f;
        }

    }

    void CheckButton()
    {
        RaycastHit hit;
        Debug.DrawRay(LookCam.transform.position,LookCam.transform.forward * 5, Color.green);
        if (Physics.Raycast(LookCam.transform.position,LookCam.transform.forward,out hit,5))
        {
            if (hit.collider.CompareTag("Button"))
            {
                CurrentCrosshairColor = CrosshairSelectColor;
            }
            else
            {
                CurrentCrosshairColor = CrosshairColor;
            }
        }
    }

    public void RecieveInput(Vector2 _mouseInput)
    {
        MouseInput.x = _mouseInput.x;
        MouseInput.y = _mouseInput.y;
    }

    public void Click()
    {
        RaycastHit hit;
        if (Physics.Raycast(LookCam.transform.position,LookCam.transform.forward,out hit,5))
        {
            if (hit.collider.CompareTag("Button"))
            {
               hit.collider.GetComponent<Scr_Button>().OnButtonPress(); 
            }

            if (IsLocked)
            {
                Weapons.Shoot();
            }
        }
    }
}
