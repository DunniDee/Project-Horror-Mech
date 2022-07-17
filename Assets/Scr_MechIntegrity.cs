using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_MechIntegrity : MonoBehaviour
{
    [SerializeField] AudioSource AboveSound;
    [SerializeField] AudioSource BelowSound;
    [SerializeField] AudioSource BehindSound;
    [SerializeField] AudioClip AboveClip;
    [SerializeField] AudioClip BelowClip;
    [SerializeField] AudioClip BehindClip;
    [SerializeField] AudioClip VentBreak;


    [SerializeField] Transform TopVent;
    [SerializeField] Transform BackVent;
    [SerializeField] Rigidbody TopVentBreak;
    [SerializeField] Rigidbody BackVentBreak;

    bool BreakVent = false;

    [SerializeField] Animator Anim;

    bool IsDead;
    bool IsTop;

    public bool CreatureIsOnHull;
    
     [SerializeField] float SecondsTillShrill;


    [SerializeField] Scr_MouseLook Look;
    // Update is called once per frame

    private void Start() 
    {
        //Invoke("GetShrilled", 5);
    }

    void AttackAbove()
    {
        Anim.SetTrigger("Above");
        Invoke("PlayUp", 0.025f);
        Look.LookTarget = new Vector2(0,-25);
        // Look.LockLerpSpeed = 1;
        Look.LockLerpSpeed = 5;
        AboveSound.PlayOneShot(VentBreak);
        IsTop = true;

    }

    void AttackBelow()
    {
        Anim.SetTrigger("Below");
        Invoke("PlayDown", 0.25f);
        Look.LookTarget = new Vector2(-65,50);
        // Look.LockLerpSpeed = 0.5f;
        Look.LockLerpSpeed = 5;
        BelowSound.PlayOneShot(VentBreak);
    }

    void AttackBehind()
    {
        Anim.SetTrigger("Behind");
        Invoke("PlayBack", 0.2f);
        Look.LookTarget = new Vector2(145,15);
        // Look.LockLerpSpeed = 0.75f;
        Look.LockLerpSpeed = 5;
        BehindSound.PlayOneShot(VentBreak);
        IsTop = false;
    }

    void PlayUp()
    {
        AboveSound.PlayOneShot(AboveClip);
        BreakVent = true;
    }
    void PlayDown()
    {
        BelowSound.PlayOneShot(BelowClip);
        BreakVent = true;
    }
    void PlayBack()
    {
        BehindSound.PlayOneShot(BehindClip);
        BreakVent = true;
    }

    public void GetShrilled()
    {
        IsDead = true;
        Look.IsDead = true;
       switch (Mathf.RoundToInt(Random.Range(0.51f,3.49f)))
       {
        case 1 :
            AttackAbove();
        break;

        case 2 :
            AttackBelow();
        break;

        case 3 :
            AttackBehind();
        break;
           
        default:
        break;
       }
    }

    private void Update() 
    {
        if (IsDead)
        {
            if (IsTop)
            {
                TopVent.localPosition = Vector3.Lerp(TopVent.localPosition,new Vector3(0,1000,0), Time.deltaTime * 2);
            }
            else
            {
                BackVent.localPosition = Vector3.Lerp(BackVent.localPosition,new Vector3(0,0,-1000), Time.deltaTime * 2);
            }
        }

        if (BreakVent)
        {
            if (IsTop)
            {
                TopVentBreak.isKinematic = false;
                TopVentBreak.AddForce(new Vector3(0,-1,0), ForceMode.VelocityChange);
            }
            else
            {
                BackVentBreak.isKinematic = false;
                BackVentBreak.AddForce(new Vector3(0,0,1), ForceMode.VelocityChange);
            }
        }

        if (CreatureIsOnHull)
        {
            SecondsTillShrill -= Time.deltaTime;
            if (!IsDead && SecondsTillShrill < 0)
            {
                GetShrilled();
            }
        }
    }
}
