using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_MechCollisions : MonoBehaviour
{
    [SerializeField] Transform[] ScannerPos;
    [SerializeField] AudioSource AS;
    [SerializeField] AudioSource ImpactAS;
    [SerializeField] AudioClip Impact;
    [SerializeField] Scr_MechMovement Movement;
    [SerializeField] Scr_MechLook MechLook;
    [SerializeField] Scr_CockpitTilter Tilt;
    [SerializeField] Animator Anim;

    bool WasColliding;
    bool Collided;

    Vector3 CollisionPos;
    public bool IsColliding;

    Vector3 CollsionTilt;

    [SerializeField] Scr_HudLightBlinker CollisionLight;



    void Update()
    {
        IsColliding = false;
        for (int i = 0; i < 8; i++)
        {
            CheckCollision(ScannerPos[i], i);
        }

        if (IsColliding)
        {
            AS.transform.position = CollisionPos;
            Tilt.RotateTo += CollsionTilt * 2 * Time.deltaTime;

            if (Movement.IsMoving || MechLook.IsRotating)
            {
                AS.volume = Mathf.Lerp (AS.volume,1,Time.deltaTime * 2);
            }
            else
            {
                AS.volume = Mathf.Lerp (AS.volume,0,Time.deltaTime * 2);  
            }

            if (!WasColliding && !Collided)
            {
                ImpactAS.PlayOneShot(Impact,0.75f);
                Tilt.RotateTo += CollsionTilt;
                Collided = true;
                Anim.SetTrigger("BigShake");
            }

            MechLook.SwivelSpeed = 25;
        }
        else
        {
            AS.volume = Mathf.Lerp (AS.volume,0,Time.deltaTime * 2);
            Collided = false;
            MechLook.SwivelSpeed = 75;
        }
        WasColliding = IsColliding;

        CollisionLight.IsBlinking = Collided;

        Anim.SetFloat("ShakeLerp", AS.volume);

    }

    void CheckCollision(Transform Pos, int index)
    {
        RaycastHit hit;
        if (Physics.Raycast(Pos.position, Pos.forward, out hit, 2))
        {
            IsColliding = true;
            CollisionPos = hit.point;

            switch (index)
            {
                case 0:
                CollsionTilt = new Vector3(-5,0,0);
                break;

                case 1:
                CollsionTilt = new Vector3(-3.5f,0,3.5f);
                break;

                case 2:
                CollsionTilt = new Vector3(0,0,5);
                break;

                case 3:
                CollsionTilt = new Vector3(3.5f,0,3.5f);
                break;

                case 4:
                CollsionTilt = new Vector3(5,0,0);
                break;

                case 5:
                CollsionTilt = new Vector3(3.5f,0,-3.5f);
                break;

                case 6:
                CollsionTilt = new Vector3(0,0,-5);
                break;

                case 7:
                CollsionTilt = new Vector3(-3.5f,0,-3.5f);
                break;

                default:
                break;
            }
        }
    }
}
