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

    [SerializeField] Animator Anim;

    bool IsDead;
    bool IsTop;
    


    [SerializeField] Scr_MouseLook Look;
    // Update is called once per frame

    private void Start() 
    {
        Invoke("GetShrilled", 5);
    }

    void AttackAbove()
    {
        Anim.SetTrigger("Above");
        Invoke("PlayUp", 0.025f);
        Look.LookTarget = new Vector2(0,-25);
        Look.LockLerpSpeed = 1;
        AboveSound.PlayOneShot(VentBreak);
        IsTop = true;

    }

    void AttackBelow()
    {
        Anim.SetTrigger("Below");
        Invoke("PlayDown", 0.25f);
        Look.LookTarget = new Vector2(-65,50);
        Look.LockLerpSpeed = 0.5f;
        BelowSound.PlayOneShot(VentBreak);
    }

    void AttackBehind()
    {
        Anim.SetTrigger("Behind");
        Invoke("PlayBack", 0.2f);
        Look.LookTarget = new Vector2(145,15);
        Look.LockLerpSpeed = 0.75f;
        BehindSound.PlayOneShot(VentBreak);
        IsTop = false;
    }

    void PlayUp()
    {
        AboveSound.PlayOneShot(AboveClip);
    }
    void PlayDown()
    {
        BelowSound.PlayOneShot(BelowClip);
    }
    void PlayBack()
    {
        BehindSound.PlayOneShot(BehindClip);
    }

    void GetShrilled()
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
                TopVent.localPosition = Vector3.Lerp(TopVent.localPosition,new Vector3(0,100,0), Time.deltaTime * 2);
            }
            else
            {
                BackVent.localPosition = Vector3.Lerp(BackVent.localPosition,new Vector3(0,0,-100), Time.deltaTime * 2);
            }
        }
    }
}
