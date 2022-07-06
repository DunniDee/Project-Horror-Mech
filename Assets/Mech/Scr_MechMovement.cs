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
    float EngineVolume;
    float EnginePitch;
    

    public bool IsGrounded;
    
    bool ToDash;


    Vector2 horizontalInput;
    Vector3 CurrentMoveVec;
    public void RecieveInput (Vector2 _horizontalInput)
    {
        horizontalInput = _horizontalInput;
    }

    private void Update() 
    { 
        IsGrounded = Physics.CheckSphere(MechAgent.position,0.5f,GroundMask);

        if (IsGrounded)
        {
            verticalVelcoity.y = 0;
        }

        Vector3 horizontalVelocity = (MechAgent.right * horizontalInput.x + MechAgent.forward * horizontalInput.y).normalized * speed;
        CurrentMoveVec = Vector3.Lerp(CurrentMoveVec,horizontalVelocity,Time.deltaTime * 5);
        controller.Move(CurrentMoveVec * Time.deltaTime);

        verticalVelcoity.y += Gravity * Time.deltaTime;
        controller.Move(verticalVelcoity * Time.deltaTime);

        if (horizontalInput != Vector2.zero)
        {
            EngineVolume = Mathf.Lerp(EngineVolume, 0.5f, Time.deltaTime );
            EnginePitch = Mathf.Lerp(EnginePitch, 1, Time.deltaTime);
        }
        else
        {
            EngineVolume = Mathf.Lerp(EngineVolume, 0.15f, Time.deltaTime);
            EnginePitch = Mathf.Lerp(EnginePitch, 0.8f, Time.deltaTime);
        }

        EngineAS.volume = EngineVolume;
        EngineAS.pitch = EnginePitch;
    }

    public void Dash()
    {

    }

    public Vector2 GetHorizontalInput()
    {
        return horizontalInput;
    }
}
