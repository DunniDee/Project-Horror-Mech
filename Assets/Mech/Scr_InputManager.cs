using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_InputManager : MonoBehaviour
{
[SerializeField] Scr_MechManager Mech;
[SerializeField] Scr_MechMovement Movement;
[SerializeField] Scr_MouseLook MouseLook;
[SerializeField] Scr_MechLook MechLook;



[SerializeField] MechControlls controlls;
MechControlls.GroundMevmentActions groundMevment;

Vector2 horizontalInput;
Vector2 mouseInput;
Vector2 mechRotation;
    private void Awake() 
    {
        controlls = new MechControlls();
        groundMevment = controlls.GroundMevment;

        groundMevment.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        groundMevment.Rotation.performed += ctx => mechRotation = ctx.ReadValue<Vector2>();

        groundMevment.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        groundMevment.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();

        groundMevment.MouseClick.performed += _ => MouseLook.Click();
        groundMevment.Dash.performed += _ => Movement.Dash();
        groundMevment.Lock.performed += _ => Mech.ToggleLock();

    }

    private void OnEnable() 
    {
        controlls.Enable();
    }

    private void OnDestroy() 
    {
        controlls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement.RecieveInput(horizontalInput);
        MouseLook.RecieveInput(mouseInput);
        MechLook.RecieveInput(mouseInput, mechRotation);

    }
}
