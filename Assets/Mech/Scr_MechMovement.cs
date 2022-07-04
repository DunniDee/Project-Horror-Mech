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

    bool ToJump;
    public bool IsGrounded;


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
        
        // if (ToJump)
        // {
        //     OnJump();
        // }

        Vector3 horizontalVelocity = (MechAgent.right * horizontalInput.x + MechAgent.forward * horizontalInput.y).normalized * speed;
        CurrentMoveVec = Vector3.Lerp(CurrentMoveVec,horizontalVelocity,Time.deltaTime * 5);
        controller.Move(CurrentMoveVec * Time.deltaTime);

        verticalVelcoity.y += Gravity * Time.deltaTime;
        controller.Move(verticalVelcoity * Time.deltaTime);
    }

    public void Jump()
    {
        // if (IsGrounded)
        // {
        //     ToJump = true;
        // }
    }

    // void OnJump()
    // {
    //     verticalVelcoity.y = Mathf.Sqrt(-2f * JumpHeight * Gravity);
    //     ToJump = false;
    // }

    public Vector2 GetHorizontalInput()
    {
        return horizontalInput;
    }
}
