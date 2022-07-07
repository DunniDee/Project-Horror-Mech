using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_MechMovement : MonoBehaviour
{
    [SerializeField] Transform MechAgent;
    [SerializeField] CharacterController controller;

    [SerializeField] float speed;
    [SerializeField] float Gravity;
    [SerializeField] float JumpHeight;
    [SerializeField] LayerMask GroundMask;
    Vector3 verticalVelcoity;

    [SerializeField] AudioSource EngineAS;
    [SerializeField] AudioClip DashSound;
    float EngineVolume;
    float EnginePitch;
    

    public bool IsGrounded;
    public bool IsMoving;
    
    
    [SerializeField] float DashSpeed;
    float CurrentDashSpeed;
    [SerializeField] float DashTime;
    float DashTimer;
    Vector3 CurrentDashVec;


    Vector2 horizontalInput;
    Vector3 CurrentMoveVec;

    [SerializeField] Scr_CockpitTilter Tilt;
    public void RecieveInput (Vector2 _horizontalInput)
    {
        horizontalInput = _horizontalInput;
    }

    private void Update() 
    { 
        Tilt.RotateTo += new Vector3(horizontalInput.y,0,-horizontalInput.x).normalized * Time.deltaTime;

        IsGrounded = Physics.CheckSphere(MechAgent.position,0.5f,GroundMask);
        if (IsGrounded)
        {
            verticalVelcoity.y = 0;
        }

        
        if (DashTimer >= 0)
        {
            DashTimer -= Time.deltaTime;
            CurrentDashSpeed = Mathf.Lerp(CurrentDashSpeed, DashSpeed, Time.deltaTime * 10);
            controller.Move(CurrentDashVec * CurrentDashSpeed * Time.deltaTime);
        }
        else
        {
            CurrentDashSpeed = Mathf.Lerp(CurrentDashSpeed, 0, Time.deltaTime * 4);
            controller.Move(CurrentDashVec * CurrentDashSpeed * Time.deltaTime);
            
            Vector3 horizontalVelocity = (MechAgent.right * horizontalInput.x + MechAgent.forward * horizontalInput.y).normalized * speed;
            CurrentMoveVec = Vector3.Lerp(CurrentMoveVec,horizontalVelocity,Time.deltaTime * 5);
            controller.Move(CurrentMoveVec * Time.deltaTime);

            if (horizontalInput != Vector2.zero)
            {
                EngineVolume = Mathf.Lerp(EngineVolume, 0.5f, Time.deltaTime );
                EnginePitch = Mathf.Lerp(EnginePitch, 1, Time.deltaTime);
                IsMoving = true;
            }
            else
            {
                EngineVolume = Mathf.Lerp(EngineVolume, 0.15f, Time.deltaTime);
                EnginePitch = Mathf.Lerp(EnginePitch, 0.8f, Time.deltaTime);
                IsMoving = false;
            }

            EngineAS.volume = EngineVolume;
            EngineAS.pitch = EnginePitch;
        }

            verticalVelcoity.y += Gravity * Time.deltaTime;
            controller.Move(verticalVelcoity * Time.deltaTime);
    }

    public void Dash()
    {
        Debug.Log("Dashing");
        DashTimer = DashTime;
        EngineAS.PlayOneShot(DashSound);
        if (horizontalInput == Vector2.zero)
        {
            CurrentDashVec = MechAgent.forward;
             Tilt.RotateTo += new Vector3(3,0,0);
        }
        else
        {
            CurrentDashVec = CurrentMoveVec;
            CurrentDashVec = CurrentDashVec.normalized;

        }
        Tilt.RotateTo += new Vector3(horizontalInput.y,0,-horizontalInput.x).normalized * 3;
    }

    public Vector2 GetHorizontalInput()
    {
        return horizontalInput;
    }
}
